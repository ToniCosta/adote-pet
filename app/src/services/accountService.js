import { api } from './api.js'

export const registrarTokenUsuario = (response) => {
    localStorage.setItem("user", JSON.stringify({
        token: response.token
    }))
}

export const fazerLogin = (email, senha) => {
    return api.post('api/account/login', { email, senha })
}

export const criarContaTutor = (model) =>  {
    return api.post('api/account/criar-conta-tutor', model)
}

export const criarContaRepresentante = (model) =>  {
    return api.post('api/account/criar-conta-representante', model)
}