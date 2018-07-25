import Vue from 'vue';

export default {
  resource: undefined,
  customActions: {
    login: {method: 'POST', url: 'account/login'},
    register: {method: 'POST', url: 'account/register'}
   },
  setUp(){
    if(this.resource === undefined){
      this.resource = Vue.resource('', {}, this.customActions);
    }
  },
  login(user) {
    this.setUp();
     return this.resource.login(user);
  },
  register(user) {
    this.setUp();
     return this.resource.register(user);
  }
}
