<template>
  <div>
    <div >
      <h1>Texto</h1>
    </div>
     <div class="row">
      <div class="large-8 column login-box-parent">
        <bd-login></bd-login>
      </div>
       <div class="large-8 column login-box-parent">
        <bd-register></bd-register>
       </div>
    </div>
  </div>
</template>

<script>
import AccountService from "@/services/account-service";
import BdLogin from "@/components/login/BdLogin";
import BdRegister from "@/components/login/BdRegister";
import bFormGroup from "bootstrap-vue/es/components/form-group/form-group";

export default {
  components: {
    BdLogin,
    BdRegister,
    bFormGroup
  },
  data() {
    return {};
  },
  methods: {}
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
