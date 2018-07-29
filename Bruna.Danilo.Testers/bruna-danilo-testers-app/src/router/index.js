import Vue from 'vue';
import Router from 'vue-router';
import Home from '@/components/Home';
import Contato from '@/components/Contato';
import SobreNos from '@/components/SobreNos';

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '',
      name: 'Home',
      component: Home
    },
    {
      path: '/contato',
      name: 'Contato',
      component: Contato
    },
    {
      path: '/sobre-nos',
      name: 'SobreNos',
      component: SobreNos
    }
  ]
});
