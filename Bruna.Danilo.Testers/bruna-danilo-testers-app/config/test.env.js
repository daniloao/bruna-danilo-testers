'use strict'
const merge = require('webpack-merge')
const devEnv = require('./dev.env')

module.exports = merge(devEnv, {
  NODE_ENV: '"testing"',
  API_URL_ADDRESS: '"http://localhost:26116/api/"',
  IBJE_ESTADOS_URL: '"http://servicodados.ibge.gov.br/api/v1/localidades/estados"',
  IBJE_CIDADE_URL: '"http://servicodados.ibge.gov.br/api/v1/localidades/estados/{UF}/municipios"'
})
