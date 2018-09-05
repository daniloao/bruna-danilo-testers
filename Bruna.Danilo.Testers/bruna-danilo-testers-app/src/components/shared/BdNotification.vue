<template>
  <div v-if="model.message !== ''">
    <b-alert :show="dismissCountDown" :variant="model.variant" :dismissible="model.dismissible" @dismissed="clearMessage()" @dismiss-count-down="countDownChanged">
      <h4 class="alert-heading" v-if="model.title !== ''">{{ model.title }}</h4>
      <p>
        {{ model.message }}
      </p>
      <hr v-if="model.footer !== ''">
      <p class="mb-0" v-if="model.footer !== ''">
        {{ model.footer }}
      </p>
    </b-alert>
  </div>
</template>

<script>
import bAlert from 'bootstrap-vue/es/components/alert/alert';

export default {
  components: {
    bAlert
  },
  data() {
    return {
      model: {},
      dismissSecs: 6,
      dismissCountDown: 0
    };
  },
  name: 'App',
  created() {
    this.clearMessage();
    this.$root.$on('set-message', this.setMessage);
    this.$root.$on('clear-message', this.clearMessage);
  },
  methods: {
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    setMessage(model) {
      this.dismissCountDown = this.dismissSecs;
      this.model = model;
    },
    clearMessage() {
      this.model = {
        title: '',
        message: '',
        footer: '',
        variant: '',
        dismissible: true
      };
    }
  },
  computed: {
  }
};
</script>
