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
						Endereço
					</v-stepper-step>

					<v-divider></v-divider>

					<v-stepper-step step="2">
						Documentação
					</v-stepper-step>

					<v-divider></v-divider>

					<v-stepper-step step="3">
						Dados básicos
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
								outlined
								dense
							></v-text-field>
						</v-col>

						<v-col
							cols="12"
							sm="6"
						>
							<v-text-field
								v-model="model.razaoSocial"
								:rules="[() => !!model.razaoSocial || 'Campo obrigatório']"
								label="Razão Social"
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
								v-model="model.nomeDiretor"
								:rules="[() => !!model.nomeDiretor || 'Campo obrigatório']"
								label="Nome Diretor/Conselheiro"
								outlined
								dense
							></v-text-field>
						</v-col>

						<v-col
							cols="12"
							sm="6"
						>
							<v-text-field
								v-model="model.cpfDiretor"
								:rules="[() => !!model.cpfDiretor || 'Campo obrigatório']"
								label="CPF Diretor/Conselheiro"
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
								v-model="model.email"
								:rules="[() => !!model.email || 'Campo obrigatório']"
								label="Email"
								outlined
								dense
							></v-text-field>
						</v-col>

						<v-col
							cols="12"
							sm="6"
						>
							<v-text-field
								v-model="model.senha"
								:rules="[() => !!model.senha || 'Campo obrigatório']"
								label="Senha de acesso"
								outlined
								dense
							></v-text-field>
						</v-col>
					</v-row>
					<v-row>
						<v-col 
							cols="12"
							sm="6">
							<v-file-input
								accept="image/png, image/jpeg, image/bmp"
								placeholder="Logomarca (Arquivo PNG ou JPEG)"
								prepend-icon="mdi-camera"
								label="Logomarca (Arquivo PNG ou JPEG)"
								:multiple="false"
								v-model="file"
								
							></v-file-input>
						</v-col>
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
							<v-text-field
								v-model="model.estado"
								:rules="[() => !!model.estado || 'Campo obrigatório']"
								label="Estado"
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.cep"
								:rules="[() => !!model.cep || 'Campo obrigatório']"
								label="CEP"
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
							<v-text-field
								v-model="model.cartaoCNPJ"
								:rules="[() => !!model.cartaoCNPJ || 'Campo obrigatório']"
								label="Cartão de CNPJ"
								outlined
								dense
							></v-text-field>
						</v-col>

						<v-col
							cols="12"
							sm="6"
						>
							<v-text-field
								v-model="model.documento1"
								:rules="[() => !!model.documento1 || 'Campo obrigatório']"
								label="Documento 1"
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
								v-model="model.documento2"
								:rules="[() => !!model.documento2 || 'Campo obrigatório']"
								label="Documento 2"
								outlined
								dense
							></v-text-field>
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

export default {
	name: 'OngRegistration',
	components: {

	},
	data: () => ({
		model: {
			cnpj: null,
			razaoSocial: null,
			nomeDiretor: null,
			cpfDiretor: null,
			email: null,
			senha: null,
			file: null,
			logradouro: null,
			numero: null,
			bairro: null,
			cidade: null,
			estado: null,
			cep: null,
			cartaoCNPJ: null,
			documento1: null,
			documento2: null
		},
		isValid: false,
		isLoading: false,
		currentStep: 1
	}),
	created() {
		
	},
	methods: {
		nextStep () {
			if (this.currentStep === 3) {
				return
			}
			this.currentStep +=  1
		}
		
	},
	watch: {
		
	}
}
</script>
