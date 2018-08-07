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
          <bd-validable-input type="text"
                              name="fullName"
                              placeholder="Digite seu nome completo"
                              :model.sync="model.fullName"
                              :atualizaModel="atualizaModel"
                              :modelState.sync="modelState"></bd-validable-input>
          </b-form-group>

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
                label="Confirme seu Email:"
                label-class="text-sm-right"
                label-for="confirmEmail">
            <bd-validable-input type="text"
                              name="confirmEmail"
                              placeholder="Confirme seu email"
                              :model.sync="model.confirmEmail"
                              :atualizaModel="atualizaModel"
                              :modelState.sync="modelState"></bd-validable-input>
          </b-form-group>

    <b-form-group horizontal
                  label-class="text-sm-right"
                  label="Sexo:"
                  label-for="sexo">
          <bd-validable-input type="radio"
                      name="sex"
                      :model.sync="model.sex"
                      :atualizaModel="atualizaModel"
                      :modelState.sync="modelState"
                      :options="sexos" ></bd-validable-input>
    </b-form-group>
         <b-form-group horizontal
                label="Estado/Cidade:"
                label-class="text-sm-right"
                label-for="cidadeEstado">
                  <div class="row" 
                      id="cidadeEstado"
                      name="cidadeEstado">
                      <div id="estadoDiv">
                        <bd-validable-input type="select"
                          placeholder="UF"
                          name="estado"
                          :model.sync="model.estado"
                          :atualizaModel="atualizaModel"
                          :modelState.sync="modelState"
                          :options="sortedEstados" 
                          :showValidadtionMessage="false"></bd-validable-input>
                      </div>
                      <div id="cidadeDiv">
                        <bd-validable-input type="select"
                          placeholder="Cidade"
                          name="cidade"
                          :model.sync="model.cidade"
                          :atualizaModel="atualizaModel"
                          :modelState.sync="modelState"
                          :options="sortedCidades" 
                          :isDisabled="cidades.length <= 0"
                          :showValidadtionMessage="false"></bd-validable-input>
                      </div>
                      <div class="validation-message">
                      <b-alert variant="danger" :show="cidadesEstadosModelState.length > 0">
                        <p class="validation-message" v-for="(message, key) in cidadesEstadosModelState" :key="key">
                          {{message}}
                        </p>
                      </b-alert>
                      </div>
                  </div>
    </b-form-group>

          <b-form-group horizontal
            label="Senha:"
            label-class="text-sm-right"
            label-for="senha">
              <bd-validable-input type="password"
                            placeholder="Digite sua senha"
                            name="password"
                            :model.sync="model.password"
                            :atualizaModel="atualizaModel"
                            :modelState.sync="modelState"></bd-validable-input>
          </b-form-group>
          <b-form-group horizontal
            label="Confirme sua senha:"
            label-class="text-sm-right"
            label-for="confirm-senha">
                <bd-validable-input type="password"
                            placeholder="Confirme sua senha"
                            name="confirmPassword"
                            :model.sync="model.confirmPassword"
                            :atualizaModel="atualizaModel"
                            :modelState.sync="modelState"></bd-validable-input>

          </b-form-group> 
          <b-form-group horizontal> 
                <bd-validable-input 
                            type="checkbox"
                            placeholder="Aceito os termos e condições"
                            name="acceptTerms"
                            :checkboxModel.sync="model.acceptTerms"
                            :atualizaModel="atualizaModel"
                            :modelState.sync="modelState"></bd-validable-input>
                            <a href="#">Termos e condições aqui!</a>
          </b-form-group>

          <b-form-group horizontal> 
            <b-button @click="register" variant="primary">Registre-se</b-button>
        </b-form-group>
      </b-form-group>
    </b-card>
  </div>
</template>

<script>
import bButton from "bootstrap-vue/es/components/button/button";
import bFormGroup from "bootstrap-vue/es/components/form-group/form-group";
import bCard from "bootstrap-vue/es/components/card/card";
import BdValidableInput from "@/components/directives/BdValidableInput";
import _ from "lodash";
import AccountService from "@/services/account-service";
import IBGEService from "@/services/ibge-service";
import MessageService from "@/services/message-service";

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
        confirmPassword: "",
        email: "",
        confirmEmail: "",
        fullName: "",
        sex: "F",
        estado: "0",
        selectedEstado: {},
        cidade: "0",
        acceptTerms: false
      },
      sexos: [
        { text: "Feminino", value: "F" },
        { text: "Masculino", value: "M" }
      ],
      estados: [],
      cidades: [],
      modelState: {},
      cidadesEstadosModelState: []
    };
  },
  watch: {
    "model.selectedEstado"() {
      this.cidadesEstadosModelState = [];
      this.model.estado = this.model.selectedEstado.value;
      console.log(this.model.estado);
      this.loadCidades(this.model.estado);
    },
    "model.cidade"() {
      this.cidadesEstadosModelState = [];
    }
  },
  methods: {
    loadCidades(estadoId) {
      this.cidades = [];
      var cidade = {
        estado: estadoId
      };

      IBGEService.getCidades(cidade).then(response => {
        response.data.forEach(currentCidade => {
          this.cidades.push({
            value: `${currentCidade.id}`,
            text: currentCidade.nome
          });
        });
      });
    },
    atualizaModel(propName, valor) {
      this.model[propName] = valor;
      if (propName === "estado") {
        this.model.selectedEstado = _.find(
          this.sortedEstados,
          item => item.value === valor
        );
      }
    },
    register() {
      AccountService.register(this.model).then(
        response => {
          this.model.password = "";
          this.model.confirmPassword = "";
          MessageService.showAlert(
            "Tester cadastrado com sucesso",
            "Parabéns você acaba de se tornar um tester, e já pode começar a usufruir das suas vantagens."
          ).then(() => {
            setInterval(() => {
              window.location.href = "/teste-produtos";
            }, 1000);
          });
        },
        error => {
          this.model.password = "";
          this.model.confirmPassword = "";
          if (error.statusText === "Bad Request") {
            if (error.body.Estado) {
              _.forEach(error.body.Estado, est => {
                this.cidadesEstadosModelState.push(est);
              });
            }
            if (error.body.Cidade) {
              _.forEach(error.body.Cidade, cid => {
                this.cidadesEstadosModelState.push(cid);
              });
            }
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
    loadEstados() {
      IBGEService.getEstados().then(response => {
        response.data.forEach(currentEstado => {
          this.estados.push({
            value: `${currentEstado.id}`,
            text: currentEstado.sigla
          });
        });
      });
    }
  },
  computed: {
    sortedEstados() {
      return _.sortBy(this.estados, [
        function(o) {
          return o.text;
        }
      ]);
    },
    sortedCidades() {
      return _.sortBy(this.cidades, [
        function(o) {
          return o.text;
        }
      ]);
    }
  },
  created() {
    this.loadEstados();
  }
};
</script>

<style scoped>
#estadoDiv {
  width: 15%;
  margin-left: 15px;
}

#cidadeDiv {
  width: 75%;
  margin-left: 4%;
}
</style>