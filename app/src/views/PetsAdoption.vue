<template>
	<v-container fluid>
		<v-row class="mx-12 my-4">
			<v-col cols="12">
				<h1 class="mb-4">Animais para adoção</h1>
				<v-row>
					<v-col cols="12" sm="12">
						<v-text-field filled label="Digite a cidade ou a raça do pet e pressione enter"
							prepend-inner-icon="mdi-magnify" v-model="termo" @keyup.enter="pesquisar"></v-text-field>
					</v-col>
				</v-row>

			</v-col>

			<lista-animais :isLoading="isLoading" :habilitaEditar="false" :habilitaAdotar="true" :list="items">
			</lista-animais>

		</v-row>
	</v-container>
</template>

<script>
import { trataErro } from '../services/api.js'
import ListaAnimais from '../components/ListaAnimais.vue'
import { buscarPets } from '../services/petService.js'

export default {
	name: 'PetsAdoption',
	components: {
		ListaAnimais
	},

	data: () => ({
		isLoading: false,
		termo: null,
		items: []
	}),

	created() {
		if (this.$route.params.filtro) {
			this.termo = this.$route.params.filtro
		}
	},

	mounted() {
		if (this.termo != null && this.termo != '') {
			this.pesquisar();
		}
	},

	methods: {
		pesquisar() {
			if (this.isLoading) {
				return
			}
			this.isLoading = true;
			this.items = [];
			buscarPets(this.termo)
				.then(({ data }) => {
					this.items = data
				})
				.catch(err => {
					trataErro(this, err)
				})
				.finally(() => {
					this.isLoading = false;
				})
		}
	}

}
</script>
