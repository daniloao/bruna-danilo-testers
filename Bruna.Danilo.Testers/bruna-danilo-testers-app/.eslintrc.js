// https://eslint.org/docs/user-guide/configuring

module.exports = {
    root: true,
    parserOptions: {
        parser: 'babel-eslint'
    },
    env: {
        browser: true,
    },
    // https://github.com/vuejs/eslint-plugin-vue#priority-a-essential-error-prevention
    // consider switching to `plugin:vue/strongly-recommended` or `plugin:vue/recommended` for stricter rules.
    extends: ['plugin:vue/essential', 'airbnb-base'],
    // required to lint *.vue files
    plugins: [
        'vue'
    ],
    // check if imports actually resolve
    settings: {
        'import/resolver': {
            webpack: {
                config: 'build/webpack.base.conf.js'
            }
        }
    },
    // add your custom rules here
    rules: {
        // don't require .vue extension when importing
        'import/extensions': ['error', 'always', {
            js: 'never',
            vue: 'never'
        }],
        // disallow reassignment of function parameters
        // disallow parameter object manipulation except for specific exclusions
        'no-param-reassign': ['error', {
            props: true,
            ignorePropertyModificationsFor: [
                'state', // for vuex state
                'acc', // for reduce accumulators
                'e' // for e.returnvalue
            ]
        }],
        // allow optionalDependencies
        'import/no-extraneous-dependencies': ['error', {
            optionalDependencies: ['test/unit/index.js']
        }],
        // allow debugger during development
        'no-debugger': process.env.NODE_ENV === 'production' ? 'error' : 'off',
        // Don't throw error for CRLF
        'linebreak-style': 0,
        'indent': [0, 2],
        'no-console': 0,
        'no-plusplus': [2, { allowForLoopAfterthoughts: true }],
        "no-bitwise": [1, { "allow": ["~", ">>>", ">>", "<<"], "int32Hint": true }],
        // Array result assignment
        "prefer-destructuring": ["error", {
            "VariableDeclarator": {
                "array": false,
                "object": true
            },
            "AssignmentExpression": {
                "array": false,
                "object": false
            }
        }, {
            "enforceForRenamedProperties": false
        }],
        "comma-dangle": [2, "never"],
        "no-param-reassign": 0,
        'import/extensions': ['off', 'always', {
            'js': 'never',
            'vue': 'never'
        }],
        "import/no-unresolved": "off",
        "object-shorthand": "off",
        "max-len": "off",
        "eol-last": "off"
    }
}