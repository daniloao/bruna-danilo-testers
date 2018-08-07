<template>
<div class="menu">
    <b-nav tabs>
        <li class="nav-tem" v-if="!isAuthenticated()">
          <router-link to="/" class="nav-link" active>Home</router-link>
        </li>
        <li class="nav-tem" v-if="isAuthenticated()">
          <router-link to="/teste-produtos" class="nav-link" active>Teste de produtos</router-link>
        </li>
        <li class="nav-tem" v-if="isAuthenticated()">
          <router-link to="/cupuns-desconto" class="nav-link" active>Cupons de Desconto</router-link>
        </li> 
        <li class="nav-tem" v-if="isAuthenticated() && isAdmin()">
          <router-link to="/campanhas" class="nav-link" active>Cadastro de campanhas</router-link>
        </li>          
        <li class="nav-tem">
        <router-link to="/sobre-nos" class="nav-link">Sobre nós</router-link>
        </li>
        <li class="nav-tem">
        <router-link to="/contato" class="nav-link">Contato</router-link>
        </li>
    </b-nav>
</div>
</template>

<script>
import AccountService from "@/services/account-service";
import bNav from "bootstrap-vue/es/components/nav/nav";

export default {
  components: {
    bNav
  },
  data() {
    return {};
  },
  methods: {
    isAuthenticated() {
      return AccountService.isAuthenticated();
    },
    isAdmin() {
      return AccountService.isAdmin();
    }
  },
  computed: {}
};
</script>