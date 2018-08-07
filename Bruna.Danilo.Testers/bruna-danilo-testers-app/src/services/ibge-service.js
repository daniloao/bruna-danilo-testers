import Vue from 'vue';

export default {
    resource: undefined,
    customActions: {
        getEstados: { method: 'GET', url: 'cidadeEstado/estados' },
        getCidades: { method: 'GET', url: 'cidadeEstado/cidades' },
        atualizaCidadesEstados: { method: 'GET', url: 'cidadeEstado/atualizaCidadesEstados' }
    },
    setUp() {
        if (this.resource === undefined) {
            this.resource = Vue.resource('', {}, this.customActions);
        }
    },
    getEstados() {
        this.setUp();
        return this.resource.getEstados();
    },
    getCidades(model) {
        this.setUp();
        return this.resource.getCidades(model);
    },
    atualizaCidadesEstados() {
        this.setUp();
        return this.resource.atualizaCidadesEstados();
    }
}