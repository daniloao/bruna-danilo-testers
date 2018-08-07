import Vue from 'vue';
import MessageService from '@/services/message-service';

export default {
  resource: undefined,
  customActions: {
    login: { method: 'POST', url: 'account/login' },
    register: { method: 'POST', url: 'account/register' },
    isAuthenticated: { method: 'POST', url: 'account/isAuthenticated' },
    hasRole: { method: 'POST', url: 'account/hasRole' },
    getRoles: { method: 'POST', url: 'account/getRoles' },
    logOut: { method: 'POST', url: 'account/logOut' }
  },
  setUp() {
    if (this.resource === undefined) {
      this.resource = Vue.resource('', {}, this.customActions);
    }
  },
  logOutApi(user) {
    this.setUp();
    return this.resource.logOut();
  },
  login(user) {
    this.setUp();
    user.name = user.email;
    return this.resource.login(user).then((response) => {
      console.log("AccountService-response");
      console.log(response);
      Vue.ls.set('user', response.data);
      Vue.ls.set('roles', response.data.userRoles);
    });
  },
  register(user) {
    this.setUp();
    user.name = user.email;
    return this.resource.register(user).then((response) => {
      Vue.ls.set('user', response.data);
      this.forceLoadSession();
    });
  },
  logOut() {
    this.logOutApi();
    this.removeLogin();
    window.location.href = "/";
  },
  removeLogin() {
    Vue.ls.remove('user');
    Vue.ls.remove('roles');
    Vue.ls.remove('lastSessionLoad');
  },
  isAuthenticated(shouldLoadSession = true) {
    if (shouldLoadSession === true)
      this.loadSession();
    return Vue.ls.get('user') !== null;
  },
  hasRole(roleName) {
    this.setUp();
    if (!this.isAuthenticated()) {
      Vue.ls.remove('roles');
      return false;
    }
    this.loadSession();

    var roles = Vue.ls.get('roles');

    if (!roles || roles.length <= 0)
      return false;

    var role = roles.find(r => { r.roleId === roleName });
    return role !== null;
  },
  isAdmin() {
    return this.hasRole('ADMIN');
  },
  loadRoles() {
    this.setUp();
    if (!this.isAuthenticated(false)) {
      Vue.ls.remove('roles');
      return;
    }

    this.resource.getRoles().then(response => {
      Vue.ls.remove('roles');
      Vue.ls.set('roles', response.data);
    }, () => {
      Vue.ls.remove('roles');
    });
  },
  loadSession() {
    this.setUp();
    var lastSessionLoad = Vue.ls.get('lastSessionLoad');

    if (!lastSessionLoad) {
      this.forceLoadSession();
      return;
    }

    let lastSessionLoadDate = new Date(lastSessionLoad);
    let agora = new Date();
    lastSessionLoadDate.setMinutes(lastSessionLoadDate.getMinutes() + 5);
    if (agora > lastSessionLoad) {
      this.forceLoadSession();
    }
  },
  forceLoadSession() {
    if (this.isAuthenticated(false)) {
      Vue.ls.set('lastSessionLoad', new Date());
      this.loadRoles();

      this.resource.isAuthenticated().then(response => {
        if (response.data !== true) {
          this.removeLogin();
        }
      },
        error => {
          this.removeLogin();
        });
    }
  }
}
