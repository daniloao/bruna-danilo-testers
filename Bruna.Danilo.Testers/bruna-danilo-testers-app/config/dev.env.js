'use strict'
const merge = require('webpack-merge')
const prodEnv = require('./prod.env')

module.exports = merge(prodEnv, {
    NODE_ENV: '"development"',
    API_URL_ADDRESS: '"http://localhost:26116/api/"',
    IBJE_ESTADOS_URL: '"https://servicodados.ibge.gov.br/api/v1/localidades/estados"',
    IBJE_CIDADE_URL: '"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{UF}/municipios"'
})
