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

export const portePetsOptions = [
    { text: 'Micro', value: 'Micro' },	
    { text: 'Pequeno', value: 'Pequeno' },
    { text: 'Médio', value: 'Médio' },
    { text: 'Grande', value: 'Grande' },
    { text: 'Gigante', value: 'Gigante' }
];

export const tamanhoPeloOptions = [
    { text: 'Curto', value: 'Curto' },
    { text: 'Médio', value: 'Médio' },
    { text: 'Longo', value: 'Longo' },
    { text: 'Sem pêlos', value: 'Sem pêlos' }
];

export const estadoCivilOptions= [
    { text: 'Solteiro', value: 'Solteiro' },	
    { text: 'Casado', value: 'Casado' },
    { text: 'União estável', value: 'União estável' },
    { text: 'Viúvo', value: 'Viúvo' },
    { text: 'Separado', value: 'Separado' }
];

export const sexoOptions = [
    { text: 'Masculino', value: 'Masculino' },	
    { text: 'Feminino', value: 'Feminino' },
    { text: 'Não informar', value: 'Não informar' }
]

export const quantidadePessoasOptions = [
    { text: '1', value: '1' },
    { text: '2', value: '2' },
    { text: '3', value: '3' },
    { text: '4', value: '4' },
    { text: '5', value: '5' },
    { text: '6', value: '6' },
    { text: '7', value: '7' },
    { text: '8', value: '8' }
]
