import { api } from './api.js'

export const registrarTokenUsuario = (response) => {
    localStorage.setItem("user", JSON.stringify(response))
}

export const getUsuarioLogado = () => {
    let user = localStorage.getItem('user');
    if (user != null) {
        return JSON.parse(user)
    }
    return null;
}

export const logOff = () => {
    localStorage.removeItem('user')
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

export const atualizarPerfilTutor = (model) =>  {
    return api.put('api/account/atualizar-perfil-tutor', model)
}

export const getPerfilTutor = () =>  {
    return api.get('api/account/perfil-tutor')
}


export const marcarPerfilCompleto = () => {
    let userJson = localStorage.getItem('user');
    if (userJson != null) {
        var user = JSON.parse(userJson);
        user.cadastroCompleto = true;
        localStorage.setItem("user", JSON.stringify(user))
    }
}
