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
								v-model="model.nome"
								:rules="[() => !!model.nome || 'Campo obrigatório']"
								label="Nome"
								outlined
								dense
							></v-text-field>
						</v-col>

						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.idade"
								:rules="[() => !!model.idade || 'Campo obrigatório']"
								label="Idade"
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-combobox
								v-model="model.sexo"
								:rules="[() => !!model.sexo || 'Campo obrigatório']"
								label="Sexo"
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
								label="Estado Civil"
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
								label="RG"
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
								label="CPF"
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
								v-model="model.email"
								:rules="[() => !!model.email || 'Campo obrigatório']"
								label="Email"
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.senha"
								:rules="[() => !!model.senha || 'Campo obrigatório']"
								label="Senha"
								outlined
								dense
							></v-text-field>
						</v-col>

					</v-row>
					<v-row>
						<v-col cols="12">
							<v-combobox
								v-model="model.quantidadePessoas"
								:rules="[() => !!model.quantidadePessoas || 'Campo obrigatório']"
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
								label="Logradouro"
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
								label="Número"
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
								:rules="[() => !!model.complemento || 'Campo obrigatório']"
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
								label="Bairro"
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
								label="Cidade"
								outlined
								dense
							></v-text-field>
						</v-col>
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

					</v-row>
					<v-row>
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
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.areaLazer"
								:rules="[() => !!model.areaLazer || 'Campo obrigatório']"
								label="Possui  área de lazer (pet) próximo a sua residência ?"
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.possuiVeterinario"
								:rules="[() => !!model.possuiVeterinario || 'Campo obrigatório']"
								label="Possui veterinário próximo a sua residência ?"
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
								label="Tipo de Residência"
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
							<v-text-field
								v-model="model.tipoPet"
								:rules="[() => !!model.tipoPet || 'Campo obrigatório']"
								label="Tipo de Animal desejado (cão ou gato)"
								outlined
								dense
							></v-text-field>
						</v-col>

						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.raca"
								:rules="[() => !!model.raca || 'Campo obrigatório']"
								label="Raça"
								outlined
								dense
							></v-text-field>
						</v-col>
						<v-col
							cols="12"
							sm="4"
						>
							<v-text-field
								v-model="model.portePet"
								:rules="[() => !!model.portePet || 'Campo obrigatório']"
								label="Porte do animal"
								outlined
								dense
							></v-text-field>
						</v-col>

					</v-row>
					<v-row>
						<v-col
							cols="12"
							sm="12"
						>
							<v-text-field
								v-model="model.motivo"
								:rules="[() => !!model.motivo || 'Campo obrigatório']"
								label="Motivo da procura de um PET ?"
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
						{{ this.currentStep === 3 == 0 ? 'PRÓXIMO' : 'CADASTRAR' }}
					</v-btn>
				</v-card-actions>
			</v-form> 
		</v-col>
	</v-row>
  </v-container>
</template>

<script>

export default {
	name: 'TutorRegistration',
	components: {

	},
	data: () => ({
		quantidadePessoas: [
			{ text: '1', value: '1' },
			{ text: '2', value: '2' },
			{ text: '3', value: '3' },
			{ text: '4', value: '4' },
			{ text: '5', value: '5' },
			{ text: '6', value: '6' },
			{ text: '7', value: '7' },
			{ text: '8', value: '8' }
		],
		model: {
			nome: null,
			idade: null,
			sexo: null,
			estadoCivil: null,
			rg: null,
			cpf: null,
			email: null,
			senha: null,
			quantidadePessoas: null,
			logradouro: null,
			numero: null,
			complemento: null,
			bairro: null,
			cidade: null,
			estado: null,
			cep: null,
			areaLazer: null,
			possuiVeterinario: null,
			tipoResidencia: null,
			tipoPet: null,
			raca: null,
			portePet: null,
			motivo: null
		},
		isValid: false,
		isLoading: false,
		steps: 1,
		currentStep: 1,
		estadoCivil: [
			{ text: 'Solteiro', value: 'Solteiro' },	
			{ text: 'Casado', value: 'Casado' },
			{ text: 'União estável', value: 'União estável' },
			{ text: 'Viúvo', value: 'Viúvo' },
			{ text: 'Separado', value: 'Separado' }
		],
		sexo: [
			{ text: 'Masculino', value: 'Masculino' },	
			{ text: 'Feminino', value: 'Feminino' },
			{ text: 'Não informar', value: 'Não informar' }
		]
	}),
	created() {
		
	},
	methods: {
		nextStep () {
			if (this.currentStep === 3) {
				alert('ENVIAR')
				return
			}
			this.currentStep +=  1
		}
		
	},
	watch: {
		
	}
}
</script>
