<template>
  <v-container fluid>
    <v-row class="mx-12 my-4">
      <v-col cols="12">
        <h1 class="mb-4">Animais para adoção</h1>
          <v-row>
            <v-col
              cols="12"
              sm="12"
            >
              <v-autocomplete
                v-model="model"
                :items="items"
                :loading="isLoading"
                :search-input.sync="search"
                chips
                clearable
                hide-details
                hide-selected
                item-text="name"
                item-value="id"
                label="Pesquisar pets"
                solo
              >
                <template v-slot:no-data>
                  <v-list-item>
                    <v-list-item-title>
                      Procure o seu <strong>Pet</strong> favorito                        
                    </v-list-item-title>
                  </v-list-item>
                </template>
                <template v-slot:selection="{ attr, on, item, selected }">
                  <v-chip
                    v-bind="attr"
                    :input-value="selected"
                    color="blue-grey"
                    class="white--text"
                    v-on="on"
                  >
                    <span v-text="item.nome"></span>
                  </v-chip>
                </template>
                <template v-slot:item="{ item }">
                  <v-list-item-avatar
                    color="indigo"
                    class="text-h5 font-weight-light white--text"
                  >
                    {{ item.nome.charAt(0) }}
                  </v-list-item-avatar>
                  <v-list-item-content>
                    <v-list-item-title v-text="item.nome"></v-list-item-title>
                    <v-list-item-subtitle v-text="item.descricao"></v-list-item-subtitle>
                  </v-list-item-content>
                </template>
              </v-autocomplete>
            </v-col>              
          </v-row>
          <v-row 
            class=""
            dense
          >
            <v-col 
              lg="4"
              xs="6"
              v-for="item in list" :key="item.id"
            >
              <v-card
                class="mx-auto mt-8"
                max-width="274"
                outlined                  
              >
                <v-list-item three-line>
                  <v-list-item-content>
                    <div class="text-h5 mb-1">
                      {{item.nome}}
                    </div>
                    <div class="text-overline mb-1">
                      {{item.raca}}
                    </div>
                    <v-list-item-subtitle>{{item.descricao}}</v-list-item-subtitle>
                  </v-list-item-content>

                  <v-list-item-avatar
                    tile
                    size="80"
                  >
                    <img src="static/images/pet-list.png" />
                  </v-list-item-avatar>
                </v-list-item>

                <v-card-actions>
                  <v-btn
                    color="red lighten-2"
                    text
					@click="openDetails(item)"
                  >
                    EDITAR
                  </v-btn>
                  <v-spacer></v-spacer>
                  <v-btn
                    color="red lighten-2"
                    text
					@click="openDetails(item)"
                  >
                    DETALHES
                  </v-btn>
                </v-card-actions>
              </v-card>
            </v-col>
          </v-row>         
      </v-col>
    </v-row>
    <v-dialog
		v-model="openDialogDetails"
		v-if="openDialogDetails"
		persistent
		max-width="791px"
    >
        <v-card>
			<v-btn
				icon
				@click="openDialogDetails = false"
			>
				<v-icon>mdi-close</v-icon>
			</v-btn>
            <v-card-text class="pb-0">
                <v-container class="pb-0">
                    <v-row>
                        <v-col cols="6">
							<div
								style="height:321px; width: 274px;"
							>
								<img :src="this.itensDetails.foto" />
							</div>
                        </v-col>
						<v-col cols="6">
							<div>
								Nome
								<p>{{this.itensDetails.nome}}</p>
							</div>
							<v-row>
								<v-col cols="4">
									Raça
									<p>{{this.itensDetails.raca}}</p>
								</v-col>
								<v-col cols="4">
									Peso
									<p>{{this.itensDetails.peso}}</p>
								</v-col>
								<v-col cols="4">
									Idade
									<p>{{this.itensDetails.idade}}</p>
								</v-col>
							</v-row>
							
							<div>
								Localização
								<p>{{this.itensDetails.localizacao}}</p>
							</div>
						</v-col>                        
                    </v-row>
                </v-container>
            </v-card-text>
            <v-card-actions>
				
				<div class="ml-4" style="width: 288px;">
					<p class="mb-0">Sobre</p>
					<p>Uma canina alegre e companheira, porte M/G. Se da bem com outros caes.</p>
				</div>
                <v-spacer></v-spacer>
                
                <v-btn
                    color="blue darken-1"
                    text
                    @click="loginTutor()"
                >
					Quero adotar agora
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
	<v-dialog
		v-model="openDialogEditDetails"
		v-if="openDialogEditDetails"
		persistent
		max-width="990px"
    >
        <v-card>
			<v-btn
				icon
				@click="openDialogEditDetails = false"
			>
				<v-icon>mdi-close</v-icon>
			</v-btn>
            <v-card-text class="pb-0">
                <v-container class="pb-0">
                    <v-row>
                        <v-col cols="4">
							<div
								
							>
								<img :src="this.itensDetails.foto" />
							</div>
                        </v-col>
						<v-col cols="8">
							<v-row>
								<v-col cols="4">
									<v-text-field
										v-model="first"
										label="Nome"
										outlined
										hide-details="auto"
										dense
									></v-text-field>
								</v-col>
								<v-col cols="4">
									<v-text-field
										v-model="first"
										label="Cor"
										outlined
										hide-details="auto"
										dense
									></v-text-field>
								</v-col>
								<v-col cols="4">
									<v-text-field
										v-model="first"
										label="Tamanho do pelo"
										outlined
										hide-details="auto"
										dense
									></v-text-field>
								</v-col>
							</v-row>
							<v-row>
								<v-col cols="4">
									<v-text-field
										v-model="first"
										label="Raça"
										outlined
										hide-details="auto"
										dense
									></v-text-field>
								</v-col>
								<v-col cols="4">
									<v-text-field
										v-model="first"
										label="Porte"
										outlined
										hide-details="auto"
										dense
									></v-text-field>
								</v-col>
								<v-col cols="4">
									<v-text-field
										v-model="first"
										label="Peso"
										outlined
										hide-details="auto"
										dense
									></v-text-field>
								</v-col>
							</v-row>
							<v-row>
								<v-col cols="4">
									<v-text-field
										v-model="first"
										label="Idade"
										outlined
										hide-details="auto"
										dense
									></v-text-field>
								</v-col>
								<v-col cols="4">
									<v-text-field
										v-model="first"
										label="Comportamento"
										outlined
										hide-details="auto"
										dense
									></v-text-field>
								</v-col>
								<v-col cols="4">
									<v-text-field
										v-model="first"
										label="Localização"
										outlined
										hide-details="auto"
										dense
									></v-text-field>
								</v-col>
								<v-col>
									<v-textarea
										auto-grow
										label="Descrição"
										rows="1"
										row-height="30"
										shaped
									></v-textarea>
								</v-col>
								
							</v-row>
						</v-col>                        
                    </v-row>
                </v-container>
            </v-card-text>
            <v-card-actions>
				
                <v-spacer></v-spacer>
                <v-btn
                    color="red darken-1"
                    text
                    @click="openDialogEditDetails = false"
                >
					Cancelar
                </v-btn>
                <v-btn
                    color="blue darken-1"
                    text
                    
                >
					Quero adotar agora
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
  </v-container>
</template>

<script>
export default {
	name: 'PetsAdoption',
	components: {},
	data: () => ({
		isLoading: false,
		items: [
			{
				id: 1,
				nome: "THOR",
				raca: "Vira-Lata",
				descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes.",
				peso: "3 kg",
				idade: "3 meses",
				localizacao: "Novo Hamburgo, NOVO HAMBURGO, RS",
				foto: "static/images/images/pet-details.png"
			},
			{
				id: 2,
				nome: "JHIMMY",
				raca: "Akita",
				descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes.",
				peso: "3 kg",
				idade: "3 meses",
				localizacao: "Novo Hamburgo, NOVO HAMBURGO, RS",
				foto: "static/images/pet-details.png"
			},
			{
				id: 3,
				nome: "HULK",
				raca: "Pit bull",
				descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes.",
				peso: "3 kg",
				idade: "3 meses",
				localizacao: "Novo Hamburgo, NOVO HAMBURGO, RS",
				foto: "/static/images/pet-details.png"
			},
		],
		list: [
			{
				id: 1,
				nome: "THOR",
				raca: "Vira-Lata",
				descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes.",
				peso: "3 kg",
				idade: "3 meses",
				localizacao: "Novo Hamburgo, NOVO HAMBURGO, RS",
				foto: "static/images/pet-details.png"
			},
			{
				id: 2,
				nome: "JHIMMY",
				raca: "Akita",
				descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes.",
				peso: "3 kg",
				idade: "3 meses",
				localizacao: "Novo Hamburgo, NOVO HAMBURGO, RS",
				foto: "static/images/pet-details.png"
			},
			{
				id: 3,
				nome: "HULK",
				raca: "Pit bull",
				descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes.",
				peso: "3 kg",
				idade: "3 meses",
				localizacao: "Novo Hamburgo, NOVO HAMBURGO, RS",
				foto: "static/images/pet-details.png"
			},
			{
				id: 4,
				nome: "THOR",
				raca: "Vira-Lata",
				descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes.",
				peso: "3 kg",
				idade: "3 meses",
				localizacao: "Novo Hamburgo, NOVO HAMBURGO, RS",
				foto: "static/images/pet-details.png"
			},
			{
				id: 5,
				nome: "JHIMMY",
				raca: "Akita",
				descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes.",
				peso: "1 kg",
				idade: "1 mes",
				localizacao: "Ceara, Ceara, CE",
				foto: "static/images/pet-details.png"
			},
			{
				id: 6,
				nome: "HULK",
				raca: "Pit bull",
				descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes.",
				peso: "7 kg",
				idade: "6 meses",
				localizacao: "São Paulo, São Paulo, SP",
				foto: "static/images/pet-details.png"
			}
		],
		model: null,
		search: null,
		tab: null,
		openDialogDetails: false,
		openDialogEditDetails: false
	}),
    watch: {
      model (val) {
        if (val != null) this.tab = 0
        else this.tab = null
      },
      search () {
        // Items have already been loaded
        // if (this.items.length > 0) return

        this.isLoading = true
        this.items = this.list
        this.isLoading = false
        // Lazily load input items
        // fetch('https://api')
        //   .then(res => res.clone().json())
        //   .then(res => {
        //     this.items = this.list
        //   })
        //   .catch(err => {
        //     console.log(err)
        //   })
        //   .finally(() => (this.isLoading = false))
      },
    },
	methods: {
		openDetails (item) {
			this.itensDetails = item
			event.target.outerText === 'DETALHES' ? this.openDialogDetails = true : this.openDialogEditDetails = true						
		}
	}
}
</script>
