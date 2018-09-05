<template>
  <div>
    <b-alert :show="message" :variant="variant" :dismissible="dismissible">{{ message }}</b-alert>
  </div>
</template>

<script>
import bAlert from 'bootstrap-vue/es/components/alert/alert';

export default {
  props: {
    message: {
      type: String,
      required: true
    },
    variant: {
      type: String,
      required: false,
      default: 'warning'
    },
    dismissible: {
      type: Boolean,
      required: false,
      default: true
    }
  },
  components: {
    bAlert
  },
  data() {
    return {};
  },
  methods: {

  },
  computed: {

  }
};
</script>
