// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue';
import App from './App';
import router from './router';
import VueResource from 'vue-resource';

Vue.use(VueResource);

console.log(process.env.API_URL_ADDRESS); 
Vue.http.options.root = process.env.API_URL_ADDRESS;
Vue.config.productionTip = false;

Vue.http.interceptors.push((request, next) => {
    next((response) => {
      console.log(response);
    });

});

new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<App/>'
});
