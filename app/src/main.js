import Vue from 'vue'
import App from './App.vue'
import Toasted from 'vue-toasted';
import vuetify from './plugins/vuetify'
import router from './router'

Vue.config.productionTip = false
Vue.use(Toasted, {
  position: 'top-center',
  duration: 5000,
  fullWidth: true,
  theme: 'outline',
  singleton: true
})
new Vue({
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app')
