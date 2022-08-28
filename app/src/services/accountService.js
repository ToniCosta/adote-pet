import { api } from './api.js'

export const fazerLogin = (login, senha) => {
    return api.post('account/login-tutor', { login, senha })
}