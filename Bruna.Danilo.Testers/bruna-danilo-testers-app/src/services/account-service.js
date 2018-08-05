import Vue from 'vue';
import MessageService from '@/services/message-service';

export default {
  resource: undefined,
  customActions: {
    login: { method: 'POST', url: 'account/login' },
    register: { method: 'POST', url: 'account/register' }
  },
  setUp() {
    if (this.resource === undefined) {
      this.resource = Vue.resource('', {}, this.customActions);
    }
  },
  login(user) {
    this.setUp();
    user.email = user.name;
    return this.resource.login(user).then((response) => {
      console.log("AccountService-response");
      console.log(response);
      Vue.ls.set('user', response.data);
    });
  },
  register(user) {
    this.setUp();
    user.email = user.name;
    return this.resource.register(user).then((response) => {
      Vue.ls.set('user', response.data);
    });
  },
  logOut() {
    Vue.ls.remove('user');
    window.location.href = "/";
  },
  isAuthenticated() {
    return Vue.ls.get('user') !== null;
  },
  hasRole(roleName) {
    if (!Vue.ls.get('user')) {
      MessageService.showExpiredMessage().then(() => {
        this.logOut();
      });
    }
    const role = Vue.ls.get('user').roles.filter(currentRole => currentRole.name === roleName);

    if (role && role[0]) {
      return true;
    }

    return false;
  },
}
