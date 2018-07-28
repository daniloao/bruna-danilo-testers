<template>
  <div id="app">
    <bd-header></bd-header>
    <router-view/>
  </div>
</template>

<script>
import BdHeader from "@/components/shared/BdHeader";
export default {
  components: {
    BdHeader
  },
  name: "App"
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
