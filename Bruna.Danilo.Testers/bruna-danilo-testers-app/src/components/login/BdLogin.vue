<template>
  <div>
    <b-card bg-variant="light" class="login-box">
      <b-form-group vertical
                    breakpoint="lg"
                    label="Login"
                    label-size="lg"
                    label-class="font-weight-bold pt-0"
                    class="mb-0">
          <b-form-group horizontal
                label="Email:"
                label-class="text-sm-right"
                label-for="email-login">

          <b-form-input id="email-login" 
                          type="text" 
                          placeholder="Entre seu email"
                          v-model="model.name"></b-form-input>
          </b-form-group>
          <b-form-group horizontal
            label="Senha:"
            label-class="text-sm-right"
            label-for="senha-login">
              <b-form-input id="senha-login" 
                              type="password" 
                              placeholder="Entre sua senha"
                              v-model="model.password"></b-form-input>
          </b-form-group>
          <b-form-group> 
            <b-button @click="login" variant="primary">Login</b-button>
        </b-form-group>
      </b-form-group>
    </b-card>
  </div>
</template>

<script>
import bFormInput from "bootstrap-vue/es/components/form-input/form-input";
import bButton from "bootstrap-vue/es/components/button/button";
import bFormGroup from "bootstrap-vue/es/components/form-group/form-group";
import bCard from "bootstrap-vue/es/components/card/card";
import AccountService from "@/services/account-service";

export default {
  components: {
    bFormInput,
    bButton,
    bFormGroup,
    bCard
  },
  data() {
    return {
      model: {
        name: "",
        password: "",
        email: ""
      }
    };
  },
  methods: {
    login() {
      console.log("model");
      console.log(this.model);
      AccountService.login(this.model);
    }
  }
};
</script>