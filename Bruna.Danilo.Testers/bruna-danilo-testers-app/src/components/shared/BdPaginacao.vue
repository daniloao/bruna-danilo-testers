<template>
  <div>
    <div class="card" v-if="isSearchable">
      <div class="card-body">
        <b-form-input type="text" placeholder="Procure por..." v-model="filtrarPorTexto" name="filtro"></b-form-input>
      </div>
    </div>
    <div v-if="!pagedResponse.models || pagedResponse.models.length <= 0">
      Nenhum dado encontrado !
    </div>
    <div v-if="pagedResponse.models && pagedResponse.models.length > 0">
      <div class="pagged-table-parent table-responsive-sm">
        <table class="table table-sm">
          <thead class="thead-light">
            <tr>
              <th v-for="(column, key) in pagedResponse.columns" :key="key" class="paged-table-column">
                <button @click="sort(column.propertyName)" class="btn btn-light">
                  <b>{{ column.columnHeader }}</b>
                </button>
                <up v-if="pagedRequest.sortModel && pagedRequest.sortModel.colId === column.propertyName && pagedRequest.sortModel.sort === 'desc'"></up>
                <down v-if="pagedRequest.sortModel && pagedRequest.sortModel.colId === column.propertyName && pagedRequest.sortModel.sort === 'asc'">
                </down>
              </th>
              <th v-for="(column, key) in actionColumns" :key="key+column.id" scope="col">{{ column.columnHeader }}</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(item, key) in pagedResponse.models" :key="key">
              <td v-for="(column, key) in pagedResponse.columns" :key="key">{{ getColumnValue(item, column) }}</td>
              <td v-for="(column, key)  in actionColumns" :key="key + column.id">
                <button class="btn btn-link" @click="column.action(item)">
                  <span class="mdi" :class="column.icon">{{ column.text }}</span>
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div class="row pagination" v-if="pagedResponse.pageCount > 0">
        <div id="pagination-button-left">
          <button @click="first()" class="btn btn-outline-dark" :disabled="pagedRequest.currentPage === 0">
            <double-left></double-left>
          </button>
          <button @click="prevPage()" class="btn btn-outline-dark" :disabled="pagedRequest.currentPage === 0">
            <left></left>
          </button>
        </div>
        <div>
          Página {{ pagedRequest.currentPage + 1 }} de {{ pagedResponse.pageCount }}
        </div>
        <div id="pagination-button-right">
          <button @click="nextPage()" class="btn btn-outline-dark" :disabled="pagedRequest.currentPage >= pagedResponse.pageCount - 1">
            <right></right>
          </button>
          <button @click="last()" class="btn btn-outline-dark" :disabled="pagedRequest.currentPage === pagedResponse.pageCount - 1">
            <double-right></double-right>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import moment from 'moment';
import numeral from 'numeral';
import DoubleLeft from 'mdi-vue/ChevronDoubleLeftIcon';
import Left from 'mdi-vue/ChevronLeftIcon';
import DoubleRight from 'mdi-vue/ChevronDoubleRightIcon';
import Right from 'mdi-vue/ChevronRightIcon';
import Up from 'mdi-vue/MenuUpIcon';
import Down from 'mdi-vue/MenuDownIcon';
import bFormInput from 'bootstrap-vue/es/components/form-input/form-input';
import bTooltip from 'bootstrap-vue/es/components/tooltip/tooltip';

export default {
  watch: {
    pagedRequest() {
      this.load();
    },
    sortColumn() {
      this.pagedRequest.sortModel = {
        sort: 'asc',
        colId: this.sortColumn
      };
      this.load();
    },
    filtrarPorTexto() {
      if (this.filtrarPorTexto !== this.pagedRequest.filtrarPorTexto) {
        this.pagedRequest.filtrarPorTexto = this.filtrarPorTexto;
        this.load();
      }
    },
    model() {
      this.pagedRequest.model = this.model;
      this.load();
    }
  },
  components: {
    DoubleLeft,
    Left,
    Right,
    DoubleRight,
    Up,
    Down,
    bFormInput,
    bTooltip
  },
  props: {
    actionColumns: {
      type: Array,
      required: false,
      default: () => []
    },
    loadData: {
      type: Function,
      required: true
    },
    model: {
      type: Object,
      required: false
    },
    sortColumn: {
      type: String,
      required: true
    },
    isSearchable: {
      type: Boolean,
      required: false,
      default: true
    }
  },
  data() {
    return {
      pagedRequest: {
        model: undefined,
        pageSize: process.env.DEFAULT_PAGE_SIZE,
        currentPage: 0,
        sortModel: undefined,
        filtrarPorTexto: ''
      },
      pagedResponse: {
        modelsResult: [],
        pageCount: 0,
        columns: []
      },
      filtrarPorTexto: ''
    };
  },
  methods: {
    nextPage() {
      this.pagedRequest.currentPage = this.pagedRequest.currentPage + 1;
      this.load();
    },
    prevPage() {
      this.pagedRequest.currentPage = this.pagedRequest.currentPage - 1;
      this.load();
    },
    first() {
      this.pagedRequest.currentPage = 0;
      this.load();
    },
    last() {
      this.pagedRequest.currentPage = this.pagedResponse.pageCount - 1;
      this.load();
    },
    getColumnValue(item, column) {
      if (column.columnType === 'datetime') return moment(String(item[column.propertyName])).format(column.format);
      if (column.columnType === 'number') return numeral(item[column.propertyName]).format(column.format);
      return item[column.propertyName];
    },
    sort(propertyName) {
      if (this.pagedRequest.sortModel && this.pagedRequest.sortModel.colId === propertyName) {
        if (this.pagedRequest.sortModel.sort === 'desc') {
          this.pagedRequest.sortModel.sort = 'asc';
        } else {
          this.pagedRequest.sortModel.sort = 'desc';
        }
      } else {
        this.pagedRequest.sortModel = {
          sort: 'asc',
          colId: propertyName
        };
      }
      this.load();
    },
    load() {
      this.loadData(this.pagedRequest).then((response) => {
        this.pagedResponse = response.data;
      }, (error) => {
        console.error(error);
      });
    }
  },
  computed: {},
  created() {
    this.pagedRequest.sortModel = {
      sort: 'asc',
      colId: this.sortColumn
    };

    this.load();
  }
};
</script>

<style scoped>
#pagination-button-left {
  width: 40%;
  margin: 10px 10px 10px 30px;
  text-align: left;
}

#pagination-button-right {
  width: 43%;
  margin: 10px 30px 10px 10px;
  text-align: right;
}
</style>
