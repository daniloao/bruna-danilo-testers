import Vue from 'vue';
// import router from '@/router';

export default {
    el: '#app',
    showAlert(title, message) {
        return Vue.dialog.alert({
            title,
            body: message
        }, {
            okText: 'Ok',
            animation: 'fade',
            backdropClose: true
        });
    },
    showConfirm(title, message) {
        return Vue.dialog.confirm({
            title,
            body: message
        }, {
            okText: 'Yes',
            animation: 'fade',
            backdropClose: true,
            cancelText: 'No'
        });
    },
    showNotification(vm, message, variant = 'success', dismissible = true, title = '', footer = '') { // , title, duration = 6000, type = 'warn') {
        vm.$root.$emit('set-message', {
            title: title,
            message: message,
            footer: footer,
            variant: variant,
            dismissible: dismissible
        });
    },
    clearNotification(vm) { // , title, duration = 6000, type = 'warn') {
        vm.$root.$emit('clear-message');
    },
    showExpiredMessage() {
        this.showNotification('Sua sessão expirou, favor faça novamente o login!', 'Sessão expirada');
    }
};