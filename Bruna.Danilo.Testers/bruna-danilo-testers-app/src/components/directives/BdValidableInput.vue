<template>
    <div>
        <div v-if="!isSelect() && !isRadio() && !isCheckbox()">
            <b-form-input
                            :type="type"
                            :placeholder="placeholder"
                            v-model="modelMutatable"
                            :name="name"></b-form-input>
        </div>
        <div v-if="isSelect()">
            <model-select :options="options"
                            v-model="modelMutatable"
                            :placeholder="placeholder"
                            :name="name"
                            :isDisabled="isDisabled"></model-select>
        </div>
        <div v-if="isRadio()">
           <b-form-radio-group v-model="modelMutatable" :options="options" :name="name">
           </b-form-radio-group>
        </div>
        <div v-if="isCheckbox()">
          <input :type="type"
                v-model="modelMutatable"
                :name="name">
          <label :for="name">{{ placeholder }}</label>
        </div>
        <b-alert variant="danger" :show="showValidadtionMessage && modesStateMessages.length > 0">
          <p class="validation-message" v-for="(message, key) in modesStateMessages" :key="key">
            {{message}}
          </p>
          </b-alert>
    </div>
</template>

<script>
import { ModelSelect } from 'vue-search-select';
import bFormGroup from 'bootstrap-vue/es/components/form-group/form-group';
import bFormInput from 'bootstrap-vue/es/components/form-input/form-input';
import bAlert from 'bootstrap-vue/es/components/alert/alert';
import StringService from '@/services/string-service';

export default {
  components: {
    'model-select': ModelSelect,
    bFormInput,
    bAlert,
    bFormGroup
  },
  props: {
    type: String,
    model: String,
    placeholder: String,
    name: String,
    modelState: {},
    sortedEstados: Array,
    atualizaModel: Function,
    options: Array,
    isDisabled: Boolean,
    checkboxModel: Boolean,
    showValidadtionMessage: {
      type: Boolean,
      default: true
    }
  },
  data() {
    return {
      modelMutatable: this.model,
      modelStateMutable: this.modelState,
      checkboxModelMutable: this.checkboxModel
    };
  },
  methods: {
    isSelect() {
      return this.type === 'select';
    },
    isRadio() {
      return this.type === 'radio';
    },
    isCheckbox() {
      return this.type === 'checkbox';
    }
  },
  created() { },
  watch: {
    modelState() {
      this.modelStateMutable = this.modelState;
    },
    model() {
      this.modelMutatable = this.model;
    },
    modelMutatable() {
      this.modelStateMutable = {};
      this.atualizaModel(this.name, this.modelMutatable);
    },
    checkboxModel() {
      this.checkboxModelMutable = this.checkboxModel;
    },
    checkboxModelMutable() {
      this.modelStateMutable = {};
      this.atualizaModel(this.name, this.modelMutatable);
    }
  },
  computed: {
    nameCase() {
      return StringService.firstToUpper(this.name);
    },
    modesStateMessages() {
      if (
        this.modelStateMutable
        && this.modelStateMutable[this.nameCase]
        && this.modelStateMutable[this.nameCase].length > 0
      ) {
        return this.modelStateMutable[this.nameCase];
      }

      return [];
    }
  }
};
</script>
