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
                label-for="email">

            <bd-validable-input type="text"
                              name="email"
                              placeholder="Digite seu email"
                              :model.sync="model.email"
                              :atualizaModel="atualizaModel"
                              :modelState.sync="modelState"></bd-validable-input>
          </b-form-group>
          <b-form-group horizontal
            label="Senha:"
            label-class="text-sm-right"
            label-for="password">
                        <bd-validable-input type="password"
                              name="password"
                              placeholder="Digite sua senha"
                              :model.sync="model.password"
                              :atualizaModel="atualizaModel"
                              :modelState.sync="modelState"></bd-validable-input>
          </b-form-group>
          <b-form-group> 
            <b-button @click="login" variant="primary">Login</b-button>
        </b-form-group>
      </b-form-group>
    </b-card>
  </div>
</template>

<script>
import BdValidableInput from "@/components/directives/BdValidableInput";
import bButton from "bootstrap-vue/es/components/button/button";
import bFormGroup from "bootstrap-vue/es/components/form-group/form-group";
import bCard from "bootstrap-vue/es/components/card/card";
import AccountService from "@/services/account-service";

export default {
  components: {
    BdValidableInput,
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
      },
      modelState: {}
    };
  },
  methods: {
    login() {
      AccountService.login(this.model).then(
        response => {
          this.model.password = "";
          this.$router.push("teste-produtos");
          this.$router.go();
        },
        error => {
          this.model.password = "";
          if (error.statusText === "Bad Request") {
            setInterval(() => {
              this.modelState = error.body;
            }, 500);
          } else {
            MessageService.showAlert(
              "Algo deu errado",
              "Estamos trabalhando para solucionar o problema."
            );
          }
        }
      );
    },
    atualizaModel(propName, valor) {
      this.model[propName] = valor;
    }
  }
};
</script>