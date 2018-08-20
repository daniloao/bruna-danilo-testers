<template>
  <div>
    <h3>Clientes</h3>
    <div class="card form-group">
      <div class="card-body">
        <div class="row form-group">
          <div class="col col-md-4">
            <b-form-input type="text" v-mask="'##.###.###/####-##'" placeholder="CNPJ" v-model="model.cnpj" name="cnpj"></b-form-input>
          </div>
          <div class="col col-md-2">
            <model-select :options="sortedEstados" v-model="model.estadoId" placeholder="UF" name="uf">
            </model-select>
          </div>
          <div class="col col-md-5">
            <model-select :options="sortedCidades" v-model="model.cidadeId" :isDisabled="cidades.length <= 0" placeholder="Cidade" name="cidade"></model-select>
          </div>
          <div class="col col-md-1 float-right">
            <button class="btn  btn-outline-primary" @click="filtrar()">Filtrar</button>
          </div>
        </div>
        <div class="row form-group float-right">
          <div class="col col-md-12">
            <button class="btn btn-primary" @click="adiciona()">Adicionar</button>
          </div>
        </div>
      </div>
    </div>
    <bd-paginacao :load-data="loadClientes" sort-column="id" :action-columns="actionColumns" :model="model"></bd-paginacao>
  </div>
</template>

<script>
import BdPaginacao from '@/components/shared/BdPaginacao';
import IBGEService from '@/services/ibge-service';
import ClienteService from '@/services/cliente-service';
import _ from 'lodash';
import { ModelSelect } from 'vue-search-select';

export default {
  watch: {
    'model.estadoId'() {
      this.model.cidadeId = 0;
      this.cidades = [];
      if (this.model.estadoId > 0) {
        this.loadCidades(this.model.estadoId);
      }
    }
  },
  components: {
    BdPaginacao,
    ModelSelect
  },
  data() {
    return {
      actionColumns: [],
      model: {
        cnpj: null,
        estadoId: 0,
        cidadeId: 0,
        isActive: true
      },
      estados: [],
      cidades: []
    };
  },
  methods: {
    loadClientes(model) {
      return ClienteService.getClientes(model);
    },
    atualiza(cliente) {
      const clienteId = cliente.id;
      this.$router.push(`/cliente/${clienteId}`);
    },
    adiciona() {
      this.$router.push('/cliente');
    },
    delete(cliente) {
      console.log('delete');
      console.log(cliente);
    },
    loadActionColumns() {
      this.actionColumns.push({
        columnHeader: '',
        action: this.atualiza,
        tooltip: 'Editar',
        icon: 'mdi-pencil',
        text: 'Editar',
        id: 'edit'
      });
      this.actionColumns.push({
        columnHeader: '',
        action: this.delete,
        tooltip: 'Deletar',
        icon: 'mdi-delete',
        text: 'Deletar',
        id: 'delete'
      });
    },
    loadEstados() {
      IBGEService.getEstados().then((response) => {
        this.estados = [];
        response.data.forEach((currentEstado) => {
          this.estados.unshift({
            value: `${currentEstado.id}`,
            text: currentEstado.sigla
          });
        });
      });
    },
    loadCidades(estadoId) {
      const cidade = {
        estado: estadoId
      };

      IBGEService.getCidades(cidade).then((response) => {
        response.data.forEach((currentCidade) => {
          this.cidades.push({
            value: `${currentCidade.id}`,
            text: currentCidade.nome
          });
        });
      });
    },
    filtrar() {
      this.model = {
        cnpj: this.model.cnpj,
        estadoId: this.model.estadoId,
        cidadeId: this.model.cidadeId,
        isActive: this.model.isActive
      };
    }
  },
  created() {
    this.loadEstados();
    this.loadActionColumns();
  },
  computed: {
    sortedEstados() {
      const se = _.sortBy(this.estados, [o => o.text]);
      se.unshift({
        value: -1,
        text: 'UF'
      });
      return se;
    },
    sortedCidades() {
      const sc = _.sortBy(this.cidades, [o => o.text]);
      sc.unshift({
        value: -1,
        text: 'Cidade'
      });

      return sc;
    }
  }
};
</script>
