import './assets/bootstrap.css'
import './assets/jexcel.css'
import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'

import $ from 'jquery'
import "bootstrap"
import "popover"


Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
    