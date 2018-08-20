import Vue from 'vue';

export default {
    resource: undefined,
    customActions: {
        getClientes: { method: 'POST', url: 'cliente/clientes' },
        saveCliente: { method: 'POST', url: 'cliente/save' },
        getCliente: { method: 'GET', url: 'cliente/cliente' }
    },
    setUp() {
        if (this.resource === undefined) {
            this.resource = Vue.resource('', {}, this.customActions);
        }
    },
    getClientes(model) {
        this.setUp();
        return this.resource.getClientes(model);
    },
    saveCliente(model) {
        this.setUp();
        return this.resource.saveCliente(model);
    },
    getCliente(id) {
        this.setUp();
        return this.resource.getCliente({ id: id });
    }
};