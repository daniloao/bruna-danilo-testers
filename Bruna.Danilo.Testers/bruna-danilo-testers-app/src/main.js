// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import AccountService from '@/services/account-service';
import MessageService from '@/services/message-service';
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'vuejs-dialog/dist/vuejs-dialog.min.css';
import '@/assets/site.css';
import Vue from 'vue';
import App from './App';
import router from './router';
import VueResource from 'vue-resource';
import NProgress from 'vue-nprogress';
import VueLocalStorage from 'vue-ls';
import VuejsDialog from 'vuejs-dialog';
import BootstrapVue from 'bootstrap-vue'

Vue.use(VueResource);
Vue.use(VuejsDialog);
Vue.use(BootstrapVue);
Vue.use(VueLocalStorage, {
  namespace: 'testers_',
});
Vue.use(NProgress, {
  latencyThreshold: 200, // Number of ms before progressbar starts showing, default: 100,
  router: false, // Show progressbar when navigating routes, default: true
  http: false // Show progressbar when doing Vue.http, default: true
});

const nprogress = new NProgress({ parent: '.nprogress-container' });

console.log(process.env.API_URL_ADDRESS);
Vue.http.options.root = process.env.API_URL_ADDRESS;
Vue.config.productionTip = false;

Vue.http.interceptors.push((request, next) => {
  const token = Vue.ls.get('token');

  console.log(token);
  if (token) {
    const parsedToken = JSON.parse(token);
    request.headers.set('Authorization', `${parsedToken.token_type} ${parsedToken.access_token}`);
  }

  next((response) => {
    console.log(response);

    if (!response.ok) {
      if (response.statusText === 'Unauthorized') {
        MessageService.showAlert('Testers - Nao autorizado', 'Essa acao nao foi autorizada, tente fazer o log out e log in novamente!');
      } else if (response.body.error === 'invalid_grant') {
        MessageService.showExpiredMessage().then(() => {
          AccountService.logOut();
        });
      } else {
        MessageService.showAlert('Testers - Erro', 'Alguma coisa deu errado, estamos trabalhando para corrigir o problema');
      }
      console.error(response);
    }
  });

});

new Vue({
  nprogress: nprogress,
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
});
