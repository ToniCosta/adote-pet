<template>
  <v-container fluid>
	<v-row class="mx-12 my-4">
		<v-col cols="12">
			<h1 class="mb-4">
				Cadastre sua ONG
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
						Documentação
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
							sm="6"
						>
							<v-text-field
								v-model="model.cnpj"
								:rules="[() => !!model.cnpj || 'Campo obrigatório']"
								label="CNPJ"
								counter="14"
								maxlength="14"
								number
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="6"
						>
							
							<v-text-field
								v-model="model.nomeDiretor"
								:rules="[() => !!model.nomeDiretor || 'Campo obrigatório']"
								label="Nome Diretor/Conselheiro"
								outlined
								dense
							></v-text-field>
						</v-col>
					</v-row>
					<v-row>
						<v-col
							cols="12"
							sm="6"
						>
							<v-text-field
								v-model="model.cpfDiretor"
								:rules="[() => !!model.cpfDiretor || 'Campo obrigatório']"
								label="CPF Diretor/Conselheiro"
								counter="11"
								maxlength="11"
								number
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col 
							cols="12"
							sm="6">
							<v-file-input
								accept="image/png, image/jpeg, image/bmp"
								placeholder="Logomarca (Arquivo PNG ou JPEG)"
								prepend-icon="mdi-camera"
								label="Logomarca (Arquivo PNG ou JPEG)"
								:multiple="false"
								v-model="logo"
								:rules="[() => !!logo || 'Campo obrigatório']"
								
							></v-file-input>
						</v-col>
					</v-row>
					<v-row>
						
					</v-row>
					
				</div>
				<div v-if="currentStep === 2">
					
					<v-row>
						<v-col
							cols="12"
							sm="10"
						>
							<v-text-field
								v-model="model.logradouro"
								:rules="[() => !!model.logradouro || 'Campo obrigatório']"
								label="Rua"
								outlined
								dense
							></v-text-field>
						</v-col>

						<v-col
							cols="12"
							sm="2"
						>
							<v-text-field
								v-model="model.numero"
								:rules="[() => !!model.numero || 'Campo obrigatório']"
								label="Número"
								outlined
								dense
							></v-text-field>
						</v-col>
					</v-row>
					<v-row>
						<v-col
							cols="12"
							sm="6"
						>
							<v-text-field
								v-model="model.bairro"
								:rules="[() => !!model.bairro || 'Campo obrigatório']"
								label="Bairro"
								outlined
								dense
							></v-text-field>
						</v-col>

						<v-col
							cols="12"
							sm="6"
						>
							<v-text-field
								v-model="model.cidade"
								:rules="[() => !!model.cidade || 'Campo obrigatório']"
								label="Cidade"
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
							<v-combobox
								v-model="model.uf"
								label="Estado*"
								:items="estados"
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
								v-model="model.cep"
								:rules="[() => !!model.cep || 'Campo obrigatório']"
								label="CEP"
								counter="8"
								maxlength="8"
								number
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
							sm="6"
						>
							<v-file-input
								accept="image/png, image/jpeg, image/bmp"
								placeholder="Cartão de CNPJ"
								:rules="[() => !!cartaoCNPJ || 'Campo obrigatório']"
								prepend-icon="mdi-camera"
								label="Cartão de CNPJ"
								:multiple="false"
								v-model="cartaoCNPJ"
								
							></v-file-input>							
						</v-col>

						<v-col
							cols="12"
							sm="6"
						>
							<v-file-input
								accept="image/png, image/jpeg, image/bmp"
								placeholder="Documento do Diretor (RG/CNH)"
								:rules="[() => !!documentoDiretor || 'Campo obrigatório']"
								prepend-icon="mdi-camera"
								label="Documento do Diretor (RG/CNH)"
								:multiple="false"
								v-model="documentoDiretor"
								
							></v-file-input>
						</v-col>
					</v-row>
				</div>

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
						{{ this.currentStep === 3 ? 'CADASTRAR' : 'PRÓXIMO' }}
					</v-btn>
				</v-card-actions>
			</v-form> 
		</v-col>
	</v-row>
  </v-container>
</template>

<script>
import { estadosOptions } from '../services/listasService.js'
export default {
	name: 'OngRegistration',
	components: {

	},
	data: () => ({
		logo: null,
		cartaoCNPJ: null,
		documentoDiretor: null,
		model: {
			cnpj: null,
			razaoSocial: null,
			nomeDiretor: null,
			cpfDiretor: null,
			email: null,
			senha: null,
			logradouro: null,
			numero: null,
			bairro: null,
			cidade: null,
			uf: null,
			cep: null,
		},
		isValid: false,
		isLoading: false,
		currentStep: 1,
		estados: estadosOptions
	}),
	created() {
		
	},
	methods: {
		nextStep () {
			if (this.currentStep === 3) {
				this.$toasted.info('Funcionalidade não implementada')
				return
			}
			this.currentStep +=  1
		}		
	},
	watch: {
		
	}
}
</script>
