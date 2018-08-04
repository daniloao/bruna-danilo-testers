import Vue from 'vue';

export default {
    firstToUpper(value) {
        return value.charAt(0).toUpperCase() + value.substr(1);
    }
};