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
      Vue.ls.set('user', response.data);
      Vue.ls.set('token', JSON.stringify(response.data.token));
    }, (error) => {
      console.log('error');
      console.log(error);
    });
  },
  register(user) {
    this.setUp();
    user.email = user.name;
    return this.resource.register(user).then((response) => {
      Vue.ls.set('user', response.data);
      Vue.ls.set('token', JSON.stringify(response.data.token));
    });
  },
  logOut() {
    Vue.ls.remove('token');
    Vue.ls.remove('user');
    this.$router.push({ path: '/' });
  },
  isAuthenticated() {
    return Vue.ls.get('token') !== null && Vue.ls.get('user') !== null;
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
