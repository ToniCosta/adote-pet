<template>
    <v-container>
    <v-row class="text-center">
		<v-col cols="5">
			<h1 class="text-left display-3 font-weight-medium">Encontre um novo<br/>pet para você!</h1>
			<h2 class="text-left headline mt-8 mb-12">Adotar ficou mais fácil e rápido.</h2>
			<v-text-field
				filled
				label="Digite a cidade ou a raça do pet e pressione enter"
				prepend-inner-icon="mdi-magnify"
				v-model="termo"
				@keyup.enter="pesquisar"
			></v-text-field>
		</v-col>
		<v-col cols="1"></v-col>
		<v-col cols="6" class="px-0 text-right">
			<img src="@/assets/pet-home.png" />          
		</v-col>
    </v-row>
    <v-row dense>
		<v-col cols="4">
			<v-card
			class="mx-auto"
			max-width="344"
			outlined
			>
			<v-list-item-avatar
				tile
				size="70"
			>
				<img src="@/assets/icons/icon-ache-pet.svg" />
			</v-list-item-avatar>
			<v-list-item three-line>
				<v-list-item-content>
					<v-list-item-title class="text-h5 mb-1">
						Ache seu Pet
					</v-list-item-title>
					<v-list-item-subtitle>Visite uma loja que tenha espaço dedicado à adoção. Lá você irá conhecer os pets das ONGs/protetores parceiros para criar a conexão perfeita com cão e/ou gato que busca um novo lar.</v-list-item-subtitle>
				</v-list-item-content>            
			</v-list-item>
			<v-card-actions>
				<v-btn
					color="red lighten-2"
					text
					@click="() => { $router.push({name: 'petsAdoption'})}"
				>
					ACESSAR
				</v-btn>
			</v-card-actions>
			</v-card>
		</v-col>
		<v-col cols="4">
			<v-card
				class="mx-auto"
				max-width="344"
				outlined
			>
			<v-list-item-avatar
				tile
				size="70"            
			>
				<img src="@/assets/icons/icon-avaliacao-adocao.svg" />          
			</v-list-item-avatar>
			<v-list-item three-line>
				<v-list-item-content>
					<v-list-item-title class="text-h5 mb-1">
						Avaliação de Adoção
					</v-list-item-title>
					<v-list-item-subtitle>A ONG/protetor parceiro irá fazer a análise do cadastro e perfil do adotante vs pet escolhido. Preenchendo os requisitos, você recebe a aprovação na hora (quando a entrevista é realizada na loja pelo voluntário da ONG/protetor)</v-list-item-subtitle>
				</v-list-item-content>            
			</v-list-item>
			</v-card>
		</v-col>
		<v-col cols="4">
			<v-card
				class="mx-auto"
				max-width="344"
				outlined
			>
				<v-list-item-avatar
					tile
					size="70"
					class="mx-0"
				>
					<img src="@/assets/icons/icon-adocao-completa.svg" />
				</v-list-item-avatar>
				<v-list-item three-line>
					<v-list-item-content>
						<v-list-item-title class="text-h5 mb-1">
							Adoção Completa
						</v-list-item-title>
						<v-list-item-subtitle>Caso seja aprovado na hora pelo voluntário da ONG/protetor, você já pode levar seu pet para casa! Se enviou o formulário online, espere o contato e a aprovação. Com tudo certo, você busca seu pet em uma loja Petz no dia combinado com a ONG/protetor.</v-list-item-subtitle>
					</v-list-item-content>            
				</v-list-item>
			</v-card>
		</v-col>
    </v-row>
  </v-container>
</template>

<script>
import { getUsuarioLogado } from '../services/accountService.js'
export default {
	name: 'HomeView',
	components: {},
	data: () => ({
		termo: ''
	}),
	created() {
		var user = getUsuarioLogado();
		if (user != null && user.role == 'INSTITUICAO') {
			this.$router.push({path: '/pets-instituicao'})
		}
	},
	methods: {
		pesquisar() {
			this.$router.push({name: 'petsAdoption', params: { filtro: this.termo }})
		}
	}
}
</script>
