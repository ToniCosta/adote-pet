import { apiFormData, api } from './api.js'

export const criarPet = (formData) => {
    return apiFormData.post(`api/pets`, formData)
}

export const listarPetsEntidade = () => {
    return api.get(`api/pets/pets-entidade`)
}

export const buscarPetEditar = (id) => {
    return api.get(`api/pets/buscar-pet-editar/${id}`)
}

export const buscarPets = (filtro) => {
    return api.get(`api/pets/buscar-pets?filtro=${filtro}`)
}
