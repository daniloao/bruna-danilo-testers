import Vue from 'vue';
import Router from 'vue-router';
import Home from '@/components/Home';
import Contato from '@/components/Contato';
import SobreNos from '@/components/SobreNos';
import TesteProdutos from '@/components/TesteProdutos';
import CuponsDesconto from '@/components/CuponsDesconto';
import CadastroCampanhas from '@/components/campanha/CadastroCampanhas';
import CadastroCliente from '@/components/cliente/CadastroCliente';
import ListaCliente from '@/components/cliente/ListaCliente';
import AccountService from '@/services/account-service';

Vue.use(Router);

const ifAuthenticated = (to, from, next) => {
    AccountService.refreshToken().then(() => {
        next();
    }, () => {
        next('/');
        // AccountService.logOut();
    });
};

const ifAdmin = (to, from, next) => {
    if (AccountService.isAdmin()) {
        next();
        return;
    }
    next('/');
};

export default new Router({
    routes: [{
            path: '/',
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
            component: TesteProdutos,
            beforeEnter: ifAuthenticated
        },
        {
            path: '/cupuns-desconto',
            name: 'CuponsDesconto',
            component: CuponsDesconto,
            beforeEnter: ifAuthenticated
        },
        {
            path: '/campanhas',
            name: 'CadastroCampanhas',
            component: CadastroCampanhas,
            beforeEnter: ifAdmin
        },
        {
            path: '/clientes',
            name: 'ListaCliente',
            component: ListaCliente,
            beforeEnter: ifAdmin
        },
        {
            path: '/cliente',
            name: 'CadastroCliente',
            component: CadastroCliente,
            beforeEnter: ifAdmin
        },
        {
            path: '/cliente/:id',
            name: 'CadastroClienteEdit',
            component: CadastroCliente,
            beforeEnter: ifAdmin
        },
        {
            path: '*',
            redirect: '/'
        }
    ]
});