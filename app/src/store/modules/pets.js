
// initial state
const state = () => ({
  isLogged: false
})

// getters
const getters = {}

// actions
const actions = {
  setLogged ({ commit }) {
    commit('setLogged', true)
  }
}

// mutations
const mutations = {
    setLogged (state, flag) {
        state.isLogged = flag
    } 
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}