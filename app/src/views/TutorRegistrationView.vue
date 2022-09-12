<template>
  <v-container fluid>
	<v-row class="mx-12 my-4">
		<v-col cols="12">
			<h1 class="mb-4">
				Cadastro de Tutor
			</h1>
			
			<v-stepper :value="currentStep">
				<v-stepper-header>
					<v-stepper-step step="1">
						Dados básicos
					</v-stepper-step>

					<v-divider></v-divider>

					<v-stepper-step step="2">
						Endereço
					</v-stepper-step>

					<v-divider></v-divider>

					<v-stepper-step step="3">
						Preferências
					</v-stepper-step>
				</v-stepper-header>
				</v-stepper>

				<v-stepper
				value="2"
				class="mt-12"
				>
			</v-stepper>
			<v-form 
				v-model="isValid"
				ref="form"
			>
				<div v-if="currentStep === 1">
					<v-row>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.idade"
								:rules="[() => !!model.idade || 'Campo obrigatório']"
								label="Idade*"
								outlined
								dense
								type="number"
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-combobox
								v-model="model.sexo"
								:rules="[() => !!model.sexo || 'Campo obrigatório']"
								label="Sexo*"
								:items="sexo"
								outlined
								:return-object="false"
								dense
							></v-combobox>
						</v-col>

					</v-row>
					<v-row>
						<v-col
							cols="12"
							sm="4"
						>
							<v-combobox
								v-model="model.estadoCivil"
								:rules="[() => !!model.estadoCivil || 'Campo obrigatório']"
								label="Estado Civil*"
								:items="estadoCivil"
								outlined
								:return-object="false"
								dense
							></v-combobox>
						</v-col>

						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.rg"
								:rules="[() => !!model.rg || 'Campo obrigatório']"
								label="RG*"
								outlined
								dense
							></v-text-field>
						</v-col>
							<v-col
								cols="12"
								sm="4"
							>
							<v-text-field
								v-model="model.cpf"
								:rules="[() => !!model.cpf || 'Campo obrigatório']"
								label="CPF*"
								counter="11"
								maxlength="11"
								number
								outlined
								dense
							></v-text-field>
						</v-col>

					</v-row>

					<v-row>
						<v-col cols="12">
							<v-combobox
								v-model="model.qdtPessoasReside"
								label="Você mora sozinho, caso não com quantas pessoas reside?"
								:items="quantidadePessoas"
								outlined
								:return-object="false"
								dense
							></v-combobox>
						</v-col>
					</v-row>
				</div>
				<div v-if="currentStep === 2">
					
					<v-row>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.logradouro"
								:rules="[() => !!model.logradouro || 'Campo obrigatório']"
								label="Logradouro*"
								outlined
								dense
							></v-text-field>
						</v-col>

						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.numero"
								:rules="[() => !!model.numero || 'Campo obrigatório']"
								label="Número*"
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.complemento"
								label="Complemento"
								outlined
								dense
							></v-text-field>
						</v-col>

					</v-row>
					<v-row>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.bairro"
								:rules="[() => !!model.bairro || 'Campo obrigatório']"
								label="Bairro*"
								outlined
								dense
							></v-text-field>
						</v-col>

						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.cidade"
								:rules="[() => !!model.cidade || 'Campo obrigatório']"
								label="Cidade*"
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-combobox
								v-model="model.uf"
								label="Estado*"
								:items="estados"
								outlined
								:return-object="false"
								dense
							></v-combobox>
						</v-col>

					</v-row>
					<v-row>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.cep"
								:rules="[() => !!model.cep || 'Campo obrigatório']"
								label="CEP*"
								type="number"
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.possuiAreaLazer"
								:rules="[() => !!model.possuiAreaLazer || 'Campo obrigatório']"
								label="Possui  área de lazer (pet) próximo a sua residência ?*"
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.veterinarioProximo"
								:rules="[() => !!model.veterinarioProximo || 'Campo obrigatório']"
								label="Possui veterinário próximo a sua residência ?*"
								outlined
								dense
							></v-text-field>
						</v-col>

					</v-row>
					<v-row>
						<v-col cols="12">
							<v-text-field
								v-model="model.tipoResidencia"
								:rules="[() => !!model.tipoResidencia || 'Campo obrigatório']"
								label="Tipo de Residência*"
								outlined
								dense
							></v-text-field>
						</v-col>
					</v-row>
				</div>
				<div v-if="currentStep === 3">
					<v-row>
						<v-col
							cols="12"
							sm="4"
						>
							<v-combobox
								v-model="model.tipoAnimalId"
								label="Espécie desejada (opcional)"
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
							sm="4"
						>
							<v-autocomplete
								v-model="model.racaId"
								:items="racasOptions"
								:loading="isLoadingRaca"
								:search-input.sync="pesquisarRaca"
								item-text="descricao"
								item-value="id"
								label="Raça (opcional)"
								placeholder="Começe a digitar para pesquisar"
								outlined
								:return-object="false"
							></v-autocomplete>

						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-combobox
								v-model="model.porte"
								label="Porte do animal (opcional)"
								:items="porteOptions"
								outlined
								:return-object="false"
							></v-combobox>

						</v-col>

					</v-row>
					<v-row>
						<v-col
							cols="12"
							sm="12"
						>
							<v-text-field
								v-model="model.motivoAdocao"
								:rules="[() => !!model.motivoAdocao || 'Campo obrigatório']"
								label="Motivo da procura de um PET ?*"
								outlined
								dense
							></v-text-field>
						</v-col>
					</v-row>
				</div>

				<v-divider></v-divider>
				<small>*campos obrigatórios</small>
				<v-card-actions>
					<v-btn
						text
						@click="$refs.form.reset()"
					>
						LIMPAR
					</v-btn>
					<v-spacer></v-spacer>
					<v-btn
						:disabled="this.currentStep === 1"
						:loading="isLoading"
						class="white--text"
						color="grey"
						depressed
						@click="this.currentStep -=  1"
					>
						VOLTAR
					</v-btn>
					<v-btn
						:disabled="!isValid"
						:loading="isLoading"
						class="white--text"
						color="redAccent"
						depressed
						@click="nextStep()"
					>
						{{ this.currentStep === 3 == 0 ? 'PRÓXIMO' : 'SALVAR' }}
					</v-btn>
				</v-card-actions>
			</v-form> 
		</v-col>
	</v-row>
  </v-container>
</template>

<script>

import { listaTiposAnimais, pesquisarRacas, portePetsOptions, sexoOptions, estadoCivilOptions, quantidadePessoasOptions, estadosOptions } from '../services/listasService.js'
import { atualizarPerfilTutor, marcarPerfilCompleto, getPerfilTutor } from '../services/accountService.js'

export default {
	name: 'TutorRegistration',
	components: {

	},
	data: () => ({
		tiposAnimaisOptions: [],
		quantidadePessoas: quantidadePessoasOptions,
		model: {
			id: null,
			idade: null,
			sexo: null,
			estadoCivil: null,
			rg: null,
			cpf: null,
			qdtPessoasReside: null,
			logradouro: null,
			numero: null,
			complemento: null,
			bairro: null,
			cidade: null,
			uf: null,
			cep: null,
			possuiAreaLazer: null,
			veterinarioProximo: null,
			tipoResidencia: null,
			racaId: null,
			porte: null, 
			tipoAnimalId: null,
			motivoAdocao: null
		},
		isValid: false,
		isLoading: false,
		currentStep: 1,
		estadoCivil: estadoCivilOptions,
		sexo: sexoOptions,
		porteOptions: portePetsOptions,
		pesquisarRaca: '',
		racasOptions: [],
		isLoadingRaca: false,
		estados: estadosOptions
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
	},
	mounted() {
		getPerfilTutor().then(({data}) => {
			this.model = data;
		})

	},
	methods: {
		nextStep () {
			if (this.currentStep === 3) {
				atualizarPerfilTutor(this.model).then(() => {
					marcarPerfilCompleto()
					this.$root.$emit('perfilCompleto')
				}).catch(error => {
					console.log(error)
				})
				return
			}
			this.currentStep +=  1
		}
	},
	watch: {
		pesquisarRaca(val) {
			if (this.isLoadingRaca)
			{
				return;
			} 
			if(this.model.tipoAnimalId == null || this.model.tipoAnimalId == '')
			{
				this.$toasted.error('Selecione a espécie');
				return;
			} 

			this.isLoadingRaca = true;
			pesquisarRacas(this.model.tipoAnimalId, val).then(({data}) => {
				this.racasOptions = data;
			}).finally(() => {
				this.isLoadingRaca = false;
			})
		},
	}
}
</script>
