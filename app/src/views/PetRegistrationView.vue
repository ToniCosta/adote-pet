<template>
  <v-container fluid>
	<v-row class="mx-12 my-4">
		<v-col cols="12">
			<h1 class="mb-4">
				Cadastro de PETs
			</h1>
			<v-form 
				v-model="isValid"
				ref="form"
			>
				<v-row>
					<v-col
						cols="12"
						sm="12"
					>
					<v-file-input
						accept="image/png, image/jpeg, image/bmp"
						placeholder="Adicionar foto do PET"
						prepend-icon="mdi-camera"
						label="Adicionar foto do PET"
						:multiple="false"
						v-model="file"
						:rules="[() => !!file || 'Campo obrigatório']"
					></v-file-input>
					</v-col>
					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="model.nome"
						:rules="[() => !!model.nome || 'Campo obrigatório']"
						label="Nome"
						outlined
					></v-text-field>
					</v-col>

					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="model.cor"
						:rules="[() => !!model.cor || 'Campo obrigatório']"
						label="Cor"
						outlined
					></v-text-field>
					</v-col>
					<v-col
						cols="12"
						sm="3"
					>
					<v-combobox
						v-model="model.tamanhoPelo"
						:rules="[() => !!model.tamanhoPelo || 'Campo obrigatório']"
						label="Tamanho do pelo"
						:items="tamanhoPeloOptions"
						outlined
						:return-object="false"
					></v-combobox>
					</v-col>

					<v-col
						cols="12"
						sm="3"
					>
					<v-combobox
						v-model="model.tipoAnimalId"
						:rules="[() => !!model.tipoAnimalId || 'Campo obrigatório']"
						label="Espécie"
						item-text="text"
						:items="tiposAnimaisOptions"
						@change="changeTipoAnimal()"
						outlined
						:return-object="false"
					>
					</v-combobox>
					</v-col>

					<v-col
						cols="12"
						sm="3"
					>
					<v-autocomplete
						v-model="model.racaId"
						:rules="[() => !!model.racaId || 'Campo obrigatório']"
						:items="racasOptions"
						:loading="isLoading"
						:search-input.sync="pesquisarRaca"
						item-text="descricao"
						item-value="id"
						label="Raça"
						placeholder="Começe a digitar para pesquisar"
						outlined
						:return-object="false"
					></v-autocomplete>


					</v-col>
				</v-row>
				<v-row>
					<v-col
						cols="12"
						sm="3"
					>
					<v-combobox
						v-model="model.porte"
						:rules="[() => !!model.porte || 'Campo obrigatório']"
						label="Porte"
						:items="porteOptions"
						outlined
						:return-object="false"
					></v-combobox>
					</v-col>

					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="model.peso"
						:rules="[() => !!model.peso || 'Campo obrigatório']"
						label="Peso aproximado (Em kg)"
						type="number"
						outlined
					></v-text-field>
					</v-col>
					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="model.idade"
						:rules="[() => !!model.idade || 'Campo obrigatório']"
						label="Idade aproximada  (Em meses)"
						type="number"
						outlined
					></v-text-field>
					</v-col>

					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="model.comportamento"
						:rules="[() => !!model.comportamento || 'Campo obrigatório']"
						label="Comportamento"
						outlined
					></v-text-field>
					</v-col>
				</v-row>
				<v-row>
					<v-col
						cols="12"
						sm="6"
					>
					<v-autocomplete
						v-model="model.localizacao"
						:rules="[() => !!model.localizacao || 'Campo obrigatório']"
						:items="cidadesOptions"
						:loading="isLoadingCidades"
						:search-input.sync="pesquisarCidade"
						item-text="descricao"
						item-value="descricao"
						label="Localização"
						placeholder="Começe a digitar para pesquisar"
						outlined
						:return-object="false"
					></v-autocomplete>
					</v-col>
					<v-col
						cols="12"
						sm="6"
					>
					<v-textarea
						auto-grow
						v-model="model.descricao"
						label="Descrição"
						:rules="[() => !!model.descricao || 'Campo obrigatório']"
						rows="3"
						row-height="30"
						shaped
					></v-textarea>
					</v-col>
				</v-row>
				<v-divider></v-divider>
				<v-card-actions>
					<v-btn
						text
						@click="$refs.form.reset()"
					>
						LIMPAR
					</v-btn>
					<v-spacer></v-spacer>
					<v-btn
						:disabled="!isValid"
						:loading="isLoading"
						class="white--text"
						color="redAccent"
						depressed
						@click="enviar()"
					>
						{{ model.id == 0 ? 'ADICIONAR' : 'ALTERAR' }}
					</v-btn>
				</v-card-actions>
			</v-form> 
		</v-col>
	</v-row>
  </v-container>
</template>

<script>
import { listaTiposAnimais, pesquisarRacas, pesquisarCidades } from '../services/listasService.js'
import { criarPet, buscarPetEditar } from '../services/petService.js'

export default {
	name: 'PetsRegistration',
	components: {

	},
	data: () => ({
		tiposAnimaisOptions: [],
		tamanhoPeloOptions: [
			{ text: 'Curto', value: 'Curto' },
			{ text: 'Médio', value: 'Médio' },
			{ text: 'Longo', value: 'Longo' },
			{ text: 'Sem pêlos', value: 'Sem pêlos' }
		],
		porteOptions: [
			{ text: 'Micro', value: 'Micro' },	
			{ text: 'Pequeno', value: 'Pequeno' },
			{ text: 'Médio', value: 'Médio' },
			{ text: 'Grande', value: 'Grande' },
			{ text: 'Gigante', value: 'Gigante' }
		],
		pesquisarRaca: '',
		pesquisarCidade: '',
		racasOptions: [],
		cidadesOptions: [],
		file: null,
		model: {
			id: 0,
			nome: null,
			cor: null,
			tamanhoPelo: null,
			tipoAnimalId: null,
			racaId: null,
			porte: null,
			peso: null,
			idade: null,
			comportamento: null,
			descricao: null,
			localizacao: null
		},
		isValid: false,
		isLoading: false,
		isLoadingCidades: false
	}),
	created() {
		listaTiposAnimais().then(({data}) => {
			data.forEach(element => {
				this.tiposAnimaisOptions.push({
					value: element.id,
					text: element.descricao
				})
			});
		})
		if (this.$route.params.id) {
			buscarPetEditar(this.$route.params.id).then(({data}) => {
				this.cidadesOptions = [
					{ descricao: data.localizacao }
				]
				this.racasOptions = [
					{ descricao: data.raca, id: data.racaId }
				]
				this.model = data;
			})
		}
	},
	methods: {
		changeTipoAnimal() {
			this.racasOptions = []
			this.model
		},
		enviar()  {
			if (this.isLoading) {
				return;
			}

			this.isLoading = true;
			if (this.model.id == 0) {
				var bodyFormData = new FormData();
				Object.keys(this.model).forEach(ele => {
					bodyFormData.append(ele, this.model[ele]);
				})
				bodyFormData.append('image', this.file); 
				criarPet(bodyFormData).then(({data})=> {
					console.log(data)
				}).finally(() => {
					this.isLoading = false;
				})
			} else {
				console.log('nao implementado')
			}
			
		}
	},
	watch: {
		pesquisarRaca(val) {
			if (this.isLoading || this.model.tipoAnimalId == null || this.model.tipoAnimalId == '')
			{
				return;
			} 
			this.isLoading = true;
			pesquisarRacas(this.model.tipoAnimalId, val).then(({data}) => {
				this.racasOptions = data;
			}).finally(() => {
				this.isLoading = false;
			})
		},
		pesquisarCidade(val) {
			if (this.isLoadingCidades || val == null || val == '')
			{
				return;
			} 
			this.isLoadingCidades = true;
			pesquisarCidades(val).then(({data}) => {
				this.cidadesOptions = data;
			}).finally(() => {
				this.isLoadingCidades = false;
			})
		}
	}
}
</script>
