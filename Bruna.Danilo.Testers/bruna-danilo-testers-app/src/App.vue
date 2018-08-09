<template>
  <div id="app">
    <bd-header></bd-header>
    <bd-menu></bd-menu>
    <router-view/>
  </div>
</template>

<script>
import BdHeader from '@/components/shared/BdHeader';
import BdMenu from '@/components/shared/BdMenu';

export default {
  components: {
    BdHeader,
    BdMenu
  },
  name: 'App',
  created() {
    window.addEventListener('beforeunload', this.logOut);
  },
  methods: {
    logOut() {
      console.log('logOut');
      // AccountService.logOut();
    }
  }
};
</script>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 10px;
}

@import "../node_modules/bootstrap/scss/bootstrap.scss";
</style>
