import Vue from 'vue';

export default {
    resource: undefined,
    customActions: {
        getEstados: { method: 'GET', url: process.env.IBJE_ESTADOS_URL }
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
    getCidades(estado) {
        var url = process.env.IBJE_CIDADE_URL.replace("{UF}", estado);
        return Vue.http.get(url);
    }
}