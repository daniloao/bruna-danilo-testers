import Vue from 'vue';

export default {
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
  showExpiredMessage() {
    return this.showAlert('Testers - Sessao expirada', 'Sua sessao expirou, favor faca novamente o login!');
  }
};
