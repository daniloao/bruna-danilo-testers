import Vue from 'vue';

export default {
    resource: undefined,
    customActions: {
        login: { method: 'POST', url: 'account/login' },
        register: { method: 'POST', url: 'account/register' },
        isAuthenticated: { method: 'POST', url: 'account/isAuthenticated' },
        hasRole: { method: 'POST', url: 'account/hasRole' },
        getRoles: { method: 'POST', url: 'account/getRoles' },
        logOut: { method: 'POST', url: 'account/logOut' },
        refreshToken: { method: 'GET', url: 'account/refreshToken' }
    },
    setUp() {
        if (this.resource === undefined) {
            this.resource = Vue.resource('', {}, this.customActions);
        }
    },
    logOutApi() {
        this.setUp();
        return this.resource.logOut();
    },
    login(user) {
        this.setUp();
        user.name = user.email;
        return this.resource.login(user).then((response) => {
            Vue.ls.set('user', response.data);
            Vue.ls.set('roles', response.data.userRoles);
        });
    },
    register(user) {
        this.setUp();
        user.name = user.email;
        return this.resource.register(user).then((response) => {
            Vue.ls.set('user', response.data);
            this.forceLoadSession();
        });
    },
    logOut() {
        this.logOutApi();
        this.removeLogin();
        window.location = '/';
    },
    removeLogin() {
        Vue.ls.remove('user');
        Vue.ls.remove('roles');
        Vue.ls.remove('lastSessionLoad');
    },
    isAuthenticated(shouldLoadSession = true) {
        if (shouldLoadSession === true) this.loadSession();
        return Vue.ls.get('user') !== null;
    },
    refreshToken() {
        this.setUp();
        return this.resource.refreshToken().then((response) => {
            Vue.ls.set('user', response.data);
            Vue.ls.set('roles', response.data.userRoles);
            Vue.ls.set('lastSessionLoad', new Date());
        });
    },
    hasRole(roleName) {
        this.setUp();
        if (!this.isAuthenticated()) {
            Vue.ls.remove('roles');
            return false;
        }
        this.loadSession();

        const roles = Vue.ls.get('roles');

        if (!roles || roles.length <= 0) return false;

        const role = roles.find(r => r.roleId === roleName);

        return role !== null;
    },
    isAdmin() {
        return this.hasRole('ADMIN');
    },
    loadRoles() {
        this.setUp();
        if (!this.isAuthenticated(false)) {
            Vue.ls.remove('roles');
            return;
        }

        this.resource.getRoles().then((response) => {
            Vue.ls.remove('roles');
            Vue.ls.set('roles', response.data);
        }, () => {
            Vue.ls.remove('roles');
        });
    },
    loadSession() {
        this.setUp();
        if (this.isAuthenticated(false)) {
            const lastSessionLoad = Vue.ls.get('lastSessionLoad');

            if (!lastSessionLoad) {
                this.refreshToken();
                return;
            }

            const lastSessionLoadDate = new Date(lastSessionLoad);
            const agora = new Date();
            lastSessionLoadDate.setMinutes(lastSessionLoadDate.getMinutes() + 10);
            if (agora > lastSessionLoad) {
                this.refreshToken();
            }
        }
    },
    forceLoadSession() {
        if (this.isAuthenticated(false)) {
            Vue.ls.set('lastSessionLoad', new Date());
            this.loadRoles();

            this.resource.isAuthenticated().then((response) => {
                    if (response.data !== true) {
                        this.removeLogin();
                    }
                },
                () => {
                    this.removeLogin();
                });
        }
    }
};