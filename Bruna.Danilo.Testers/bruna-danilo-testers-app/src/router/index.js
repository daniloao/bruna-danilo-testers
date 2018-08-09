import Vue from 'vue';
import Router from 'vue-router';
import Home from '@/components/Home';
import Contato from '@/components/Contato';
import SobreNos from '@/components/SobreNos';
import TesteProdutos from '@/components/TesteProdutos';
import CuponsDesconto from '@/components/CuponsDesconto';
import CadastroCampanhas from '@/components/CadastroCampanhas';

Vue.use(Router);

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
    },
    {
      path: '/teste-produtos',
      name: 'TesteProdutos',
      component: TesteProdutos
    },
    {
      path: '/cupuns-desconto',
      name: 'CuponsDesconto',
      component: CuponsDesconto
    },
    {
      path: '/campanhas',
      name: 'CadastroCampanhas',
      component: CadastroCampanhas
    }
  ]
});
