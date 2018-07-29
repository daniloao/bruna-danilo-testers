<template>
<div class="menu">
    <b-nav tabs>
        <li class="nav-tem">
        <router-link to="/" class="nav-link" active>Home</router-link>
        </li>
        <li class="nav-tem">
        <router-link to="/sobre-nos" class="nav-link">Sobre nós</router-link>
        </li>
        <li class="nav-tem">
        <router-link to="/contato" class="nav-link">Contato</router-link>
        </li>
    </b-nav>
</div>
</template>

<script>
import bNav from "bootstrap-vue/es/components/nav/nav";

export default {
  components: {
    bNav
  },
  data() {
    return {};
  },
  methods: {}
};
</script>