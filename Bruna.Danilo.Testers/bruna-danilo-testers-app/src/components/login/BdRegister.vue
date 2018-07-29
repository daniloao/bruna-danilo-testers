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
                label="Nome:"
                label-class="text-sm-right"
                label-for="nome">

          <b-form-input id="nome" 
                          type="text" 
                          placeholder="Nome"
                          v-model="model.fullName"></b-form-input>
          </b-form-group>

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
                label="Confirme seu Email:"
                label-class="text-sm-right"
                label-for="confirmEmail">

          <b-form-input id="confirmEmail" 
                          type="text" 
                          placeholder="Confirme seu email"
                          v-model="model.confirmEmail"></b-form-input>
          </b-form-group>

    <b-form-group horizontal
                  label-class="text-sm-right"
                  label="Sexo:"
                  label-for="sexo">
      <b-form-radio-group id="sexo" v-model="model.sex" :options="sexos" name="sexo">
      </b-form-radio-group>
    </b-form-group>

         <b-form-group horizontal
                label="Estado:"
                label-class="text-sm-right"
                label-for="confirmEmail">
          <model-select :options="estados"
                  v-model="model.estado"
                  placeholder="Selecione um estado">
         </model-select>
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
import { ModelSelect } from "vue-search-select";
import AccountService from "@/services/account-service";
import IBGEService from "@/services/ibge-service";

export default {
  components: {
    bFormInput,
    bButton,
    bFormGroup,
    bCard,
    ModelSelect
  },
  data() {
    return {
      model: {
        name: "",
        password: "",
        confirmPassword: "",
        email: "",
        confirmEmail: "",
        fullName: "",
        sex: "F",
        estado: "",
        city: "",
        acceptTerms: false
      },
      sexos: [
        { text: "Feminino", value: "F" },
        { text: "Masculino", value: "M" }
      ],
      estados: []
    };
  },
  methods: {
    register() {
      AccountService.register(this.model);
    },
    loadEstados() {
      IBGEService.getEstados().then(response => {
        response.data.forEach(currentEstado => {
          this.estados.push({
            id: currentEstado.id,
            value: currentEstado.sigla,
            text: currentEstado.sigla
          });
        });
      });
      this.estados = _.sortBy(this.estados, "text");

      console.log(this.estados);
    }
  },
  created() {
    this.loadEstados();
  }
};
</script>