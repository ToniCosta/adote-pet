import { api } from './api.js'

export const pesquisarCidades = (cidade) => {
    return api.get(`api/listas/cidades?cidade=${cidade}`)
}

export const listaTiposAnimais = () => {
    return api.get(`api/listas/tipos-animais`)
}

export const pesquisarRacas = (tipoAnimalId, raca) => {
    return api.get(`api/listas/racas?tipoAnimalId=${tipoAnimalId}&raca=${raca}`)
}
