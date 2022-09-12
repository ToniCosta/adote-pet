<template>
	<v-container>

		<v-row class="mx-12 my-4">
			<v-col cols="12">
				<v-text-field
					v-model="campoPesquisa"
					label="Digite para filtrar na lista de pets"
					outlined
					hide-details="auto"
					dense
					@keyup="filtrar()"
				></v-text-field>
			</v-col>
		</v-row>
		<v-row class="mx-12 my-4">
			<v-col cols="12">
				<h1>Meus pets</h1>
			</v-col>
			<lista-animais :isLoading="isLoading" :habilitaEditar="false" :list="listFiltered.filter(m => { return m.statusPet == 'Adotado' })"></lista-animais>

			<v-col cols="12">
				<h1>Pets em processo de adoção</h1>
			</v-col>
			<lista-animais :isLoading="isLoading" :habilitaEditar="false" :list="listFiltered.filter(m => { return m.statusPet == 'Em processo de adoção' })"></lista-animais>

		</v-row>

	</v-container>
</template>

<script>
import { trataErro } from '../services/api.js'
import ListaAnimais from '../components/ListaAnimais.vue'
import { listarPetsTutor } from '../services/petService.js'

export default {
	name: 'PetsAdoptionTutor',
	components: {
		ListaAnimais
	},
	data: () => ({
		list: [],
		listFiltered: [],
		isLoading: true,
		campoPesquisa: ''
	}),
	mounted() {
		listarPetsTutor().then(({data}) => {
			this.list = data
			this.listFiltered = [...this.list]
		})
		.catch(error => {
			trataErro(this, error)
		})
		.finally(() => {
			this.isLoading = false;
		})
	},
	methods: {
		isMatch(vl, filtro) {
			if (vl == null || vl == '') {
				return true;
			}
			return vl.toUpperCase().includes(filtro)
		},
		filtrar() {
			let filtro = this.campoPesquisa.toUpperCase()
			if (filtro == '') {
				this.listFiltered = [...this.list]
				return;
			}
			this.listFiltered = this.list.filter(m => {
				return this.isMatch(m.nome, filtro) || 
					this.isMatch(m.raca, filtro) ||
					this.isMatch(m.localizacao, filtro) ||
					this.isMatch(m.descricao, filtro)
			})
		}
	}
}
</script>
