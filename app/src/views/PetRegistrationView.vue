<template>
  <v-container fluid>
	<v-row class="mx-12 my-4">
		<v-col cols="12">
			<h1 class="mb-4">
				Cadastro de PETs
			</h1>
			<v-form 
				v-model="form"
				ref="form"
			>
				<v-row>
					<v-col
						cols="12"
						sm="12"
					>
					<v-file-input
						:rules="rules"
						accept="image/png, image/jpeg, image/bmp"
						placeholder="Adicionar foto do PET"
						prepend-icon="mdi-camera"
						label="Adicionar foto do PET"
					></v-file-input>
					</v-col>
					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="first"
						label="Nome"
						outlined
					></v-text-field>
					</v-col>

					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="last"
						label="Cor"
						outlined
					></v-text-field>
					</v-col>
					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="first"
						label="Tamanho do pelo"
						outlined
					></v-text-field>
					</v-col>

					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="last"
						label="Raça"
						outlined
					></v-text-field>
					</v-col>
				</v-row>
				<v-row>
					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="first"
						label="Porte"
						outlined
					></v-text-field>
					</v-col>

					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="last"
						label="Peso"
						outlined
					></v-text-field>
					</v-col>
					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="first"
						label="Idade"
						outlined
					></v-text-field>
					</v-col>

					<v-col
						cols="12"
						sm="3"
					>
					<v-text-field
						v-model="last"
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
					<v-textarea
						auto-grow
						label="Localização"
						rows="1"
						row-height="30"
						shaped
					></v-textarea>
					</v-col>
					<v-col
						cols="12"
						sm="6"
					>
					<v-textarea
						auto-grow
						label="Descrição"
						rows="1"
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
						:disabled="!form"
						:loading="isLoading"
						class="white--text"
						color="redAccent"
						depressed
					>
						ADICIONAR
					</v-btn>
				</v-card-actions>
			</v-form> 
		</v-col>
	</v-row>
  </v-container>
</template>

<script>
export default {
  name: 'HomeView',
  components: {
    
  },
  data: () => ({
    form: false,
  }),
  created() {
  }  
}
</script>
