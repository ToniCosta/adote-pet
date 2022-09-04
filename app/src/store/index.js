import Vue from 'vue'
import Vuex from 'vuex'
import pets from './modules/pets'

Vue.use(Vuex)

const debug = process.env.NODE_ENV !== 'production'

export default new Vuex.Store({
  modules: {
    pets
  },
  strict: debug
})