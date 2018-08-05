<template>
  <div class="row">
      <div v-if="isAuthenticated()" class="header-loggedin">
        <span>
          {{ userName }} | <a href="#" @click="logOut">Log out</a>
        </span>
      </div>
      <div class="header">
        <h1>Header</h1>
      </div>
  </div>
</template>

<script>
import Vue from "vue";
import AccountService from "@/services/account-service";

export default {
  data() {
    return {};
  },
  methods: {
    logOut() {
      AccountService.logOut();
    },
    isAuthenticated() {
      return AccountService.isAuthenticated();
    }
  },
  computed: {
    userName() {
      let user = Vue.ls.get("user");
      if (user) return user.email;

      return "";
    }
  }
};
</script>