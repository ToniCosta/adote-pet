import { apiFormData } from './api.js'

export const criarPet = (formData) => {
    return apiFormData.post(`api/pets`, formData)
}
