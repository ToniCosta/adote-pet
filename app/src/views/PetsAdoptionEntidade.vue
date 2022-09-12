<template>
	<v-container>
		<v-row class="mx-12 my-4">
			<v-col cols="12">
				<h1 class="mb-4">Animais da instituição</h1>
			</v-col>

			<lista-animais :habilitaEditar="true" :list="list"></lista-animais>

		</v-row>

	</v-container>
</template>

<script>
import ListaAnimais from '../components/ListaAnimais.vue'
import { listarPetsEntidade } from '../services/petService.js'

export default {
	name: 'PetsAdoptionEntidade',
	components: {
		ListaAnimais
	},
	data: () => ({
		list: [],
	}),
	mounted() {
		listarPetsEntidade().then(({data}) => {
			this.list = data
		})
	},
	methods: {
	}
}
</script>
