// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import AccountService from '@/services/account-service';
import MessageService from '@/services/message-service';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import 'vuejs-dialog/dist/vuejs-dialog.min.css';
import 'nprogress/nprogress.css';
import 'vue-material/dist/vue-material.css';
import '@/assets/site.css';
// You also need to import the styles. If you're using webpack's css-loader, you can do so here:
import 'vue-snotify/styles/material.css'; // or dark.css or simple.css
import 'babel-polyfill';
import Vue from 'vue';
import App from './App';
import router from './router';
import VueResource from 'vue-resource';
import NProgress from 'nprogress';
import VueLocalStorage from 'vue-ls';
import VuejsDialog from 'vuejs-dialog';
import BootstrapVue from 'bootstrap-vue';
import { ModelSelect } from 'vue-search-select';
import VTooltip from 'v-tooltip';
import VueMaterial from 'vue-material';
import VueMask from 'v-mask';
import Vuelidate from 'vuelidate';
import Notifications from 'vue-notification';
import Snotify from 'vue-snotify';

Vue.use(Snotify);
Vue.use(Notifications);
Vue.use(Vuelidate);
Vue.use(VueMask);
Vue.use(VueMaterial);
Vue.use(VTooltip);
Vue.use(VueResource);
Vue.use(VuejsDialog);
Vue.use(BootstrapVue);
Vue.use(VueLocalStorage, {
    namespace: 'testers_'
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
                if (response.url.indexOf('refreshToken') < 0) {
                    MessageService.showNotification('Essa ação não foi autorizada, tente fazer o log out e log in novamente!', 'Não autorizado');
                    AccountService.logOut();
                }
            } else if (response.body.error === 'invalid_grant') {
                MessageService.showExpiredMessage();
                AccountService.logOut();
            }
        }
    });
});

(() => new Vue({
    el: '#app',
    router,
    components: { App },
    template: '<App/>',
    render: h => h(App)
}))();