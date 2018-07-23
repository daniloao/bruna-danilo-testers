import Vue from 'vue';

export default {
  resource: undefined,
  customActions: {
    login: {method: 'POST', url: 'account/login'},
    createUser: {method: 'POST', url: 'account/createUser'}
   },
  setUp(){
    if(this.resource === undefined){
      this.resource = Vue.resource('', {}, this.customActions);
    }
  },
  login() {
    this.setUp();
     return this.resource.login();
  },
  createUser(user) {
    this.setUp();
     return this.resource.createUser(user);
  }
}
