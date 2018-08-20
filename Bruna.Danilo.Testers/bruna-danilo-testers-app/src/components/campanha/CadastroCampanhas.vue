<template>
  <div>
    <h1>Cadastro de Campanhas</h1>
    <button @click="atualizaCidadesEstados">Atualiza Cidades e Estados</button>
  </div>
</template>

<script>
import IBGEService from '@/services/ibge-service';

export default {
  data() {
    return {};
  },
  methods: {
    atualizaCidadesEstados() {
      IBGEService.atualizaCidadesEstados().then(
        (resp) => {
          console.log(resp);
        },
        (error) => {
          console.log(error);
        }
      );
    }
  }
};
</script>
