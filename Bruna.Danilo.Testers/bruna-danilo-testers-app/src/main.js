// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import AccountService from '@/services/account-service';
import MessageService from '@/services/message-service';
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'vuejs-dialog/dist/vuejs-dialog.min.css';
import 'nprogress/nprogress.css';
import '@/assets/site.css';
import Vue from 'vue';
import App from './App';
import router from './router';
import VueResource from 'vue-resource';
import NProgress from 'nprogress';
import VueLocalStorage from 'vue-ls';
import VuejsDialog from 'vuejs-dialog';
import BootstrapVue from 'bootstrap-vue'
import { ModelSelect } from "vue-search-select";

Vue.use(VueResource);
Vue.use(VuejsDialog);
Vue.use(BootstrapVue);
Vue.use(VueLocalStorage, {
  namespace: 'testers_',
});

Vue.component('model-select', ModelSelect);

Vue.http.options.root = process.env.API_URL_ADDRESS;
Vue.config.productionTip = false;

Vue.http.interceptors.push((request, next) => {
  NProgress.start();
  const user = Vue.ls.get('user');

  if (user && user.token) {
    request.headers.set('Authorization', `Bearer ${user.token}`);
  }

  next((response) => {
    NProgress.done();
    console.log(response);

    if (!response.ok) {
      if (response.statusText === 'Unauthorized') {
        MessageService.showAlert('Testers - Não autorizado', 'Essa ação não foi autorizada, tente fazer o log out e log in novamente!');
      } else if (response.body.error === 'invalid_grant') {
        MessageService.showExpiredMessage().then(() => {
          AccountService.logOut();
        });
      }
    }
  });

});

new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
});
