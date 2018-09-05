<template>
  <div id="app">
    <bd-header></bd-header>
    <bd-menu></bd-menu>
    <bd-notification></bd-notification>
    <router-view />
  </div>
</template>

<script>
import BdHeader from '@/components/shared/BdHeader';
import BdMenu from '@/components/shared/BdMenu';
import BdNotification from '@/components/shared/BdNotification';
import bAlert from 'bootstrap-vue/es/components/alert/alert';

export default {
  components: {
    BdHeader,
    BdMenu,
    bAlert,
    BdNotification
  },
  data() {
    return {
      model: {}
    };
  },
  name: 'App',
  created() {
  },
  methods: {
  },
  computed: {
  }
};
</script>

<style>
#app {
  margin-top: 10px;
  color: #2c3e50;
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  text-align: center;

  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

@import "../node_modules/bootstrap/scss/bootstrap.scss";
</style>
