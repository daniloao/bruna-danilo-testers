AccountService = {
 resource: undefinied,
 customActions: {
    login: {method: 'POST', url: '\account\login'}
 },
 login() {
   if(!this.resource){
      AccountService.initResource();
    }  
    resurn AccountService.resource.login();
 },
 initResource() {
  AccountService.resource = AccountService.$resource('', {}, AccountService.customActions);
 }
}