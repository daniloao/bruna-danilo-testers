'use strict'
const merge = require('webpack-merge')
const prodEnv = require('./prod.env')

module.exports = merge(prodEnv, {
    NODE_ENV: '"development"',
    API_URL_ADDRESS: '"http://localhost:26116/api/"',
    DEFAULT_PAGE_SIZE: 15
})