<template>
  <div>
     <div class="row" v-if="!isAuthenticated()">
      <div class="large-8 column login-box-parent">
        <div>
          <h1>Texto</h1>
        </div>
      </div>
       <div class="large-8 column login-box-parent">
         <b-card no-body>
  <b-tabs card>
    <b-tab title="Cadastre-se" active>
      <bd-register></bd-register>
    </b-tab>
    <b-tab title="Login">
      <bd-login></bd-login>
    </b-tab>
  </b-tabs>
</b-card>
        
       </div>
    </div>
    <div v-if="isAuthenticated()">
      <button @click="atualizaCidadesEstados">Atualiza</button>
      </div>
  </div>
</template>

<script>
import AccountService from "@/services/account-service";
import IBGEService from "@/services/ibge-service";
import BdLogin from "@/components/login/BdLogin";
import BdRegister from "@/components/login/BdRegister";
import bFormGroup from "bootstrap-vue/es/components/form-group/form-group";
import bTabs from "bootstrap-vue/es/components/tabs/tabs";
import bTab from "bootstrap-vue/es/components/tabs/tab";

export default {
  components: {
    BdLogin,
    BdRegister,
    bFormGroup,
    bTabs,
    bTab
  },
  data() {
    return {};
  },
  methods: {
    isAuthenticated() {
      return AccountService.isAuthenticated();
    },
    atualizaCidadesEstados() {
      IBGEService.atualizaCidadesEstados().then(
        resp => {
          console.log(resp);
        },
        error => {
          console.log(error);
        }
      );
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1,
h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
