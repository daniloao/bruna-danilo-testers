<template>
  <div>
    <b-card bg-variant="light" class="login-box">
      <b-form-group vertical
                    breakpoint="lg"
                    label="Registre-se"
                    label-size="lg"
                    label-class="font-weight-bold pt-0"
                    class="mb-0">
          <b-form-group horizontal
                label="Email:"
                label-class="text-sm-right"
                label-for="email">

          <b-form-input id="email" 
                          type="text" 
                          placeholder="Entre seu email"
                          v-model="model.name"></b-form-input>
          </b-form-group>
          <b-form-group horizontal
            label="Senha:"
            label-class="text-sm-right"
            label-for="senha">
              <b-form-input id="senha" 
                              type="password" 
                              placeholder="Entre sua senha"
                              v-model="model.password"></b-form-input>
          </b-form-group>
          <b-form-group horizontal
            label="Confirme sua senha:"
            label-class="text-sm-right"
            label-for="confirm-senha">
              <b-form-input id="confirm-senha" 
                              type="password" 
                              placeholder="Confirme sua senha"
                              v-model="model.confirmPassword"></b-form-input>
          </b-form-group>          
          <b-form-group> 
                  
            <b-button @click="register" variant="primary">Registre-se</b-button>
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
        confirmPassword: "",
        email: ""
      }
    };
  },
  methods: {
    register() {
      AccountService.register(this.model);
    }
  }
};
</script>