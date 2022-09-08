<template>
  <v-container fluid>
    <v-row class="mx-12 my-4">
      <v-col cols="12">
        <h1 class="mb-4">Animais para adoção</h1>
          <v-container>
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
                      <img src="@/assets/pet-list.png" />
                    </v-list-item-avatar>
                  </v-list-item>

                  <v-card-actions>
                    <v-btn
                      color="red lighten-2"
                      text
                    >
                      EDITAR
                    </v-btn>
                    <v-spacer></v-spacer>
                    <v-btn
                      color="red lighten-2"
                      text
                    >
                      DETALHES
                    </v-btn>
                  </v-card-actions>
                </v-card>
              </v-col>
            </v-row>         
          </v-container>
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
      isLoading: false,
      items: [
        {
          id: 1,
          nome: "THOR",
          raca: "Vira-Lata",
          descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes."
        },
        {
          id: 2,
          nome: "JHIMMY",
          raca: "Akita",
          descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes."
        },
        {
          id: 3,
          nome: "HULK",
          raca: "Pit bull",
          descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes."
        },
      ],
      list: [
        {
          id: 1,
          nome: "THOR",
          raca: "Vira-Lata",
          descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes."
        },
        {
          id: 2,
          nome: "JHIMMY",
          raca: "Akita",
          descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes."
        },
        {
          id: 3,
          nome: "HULK",
          raca: "Pit bull",
          descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes."
        },
        {
          id: 4,
          nome: "THOR",
          raca: "Vira-Lata",
          descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes."
        },
        {
          id: 5,
          nome: "JHIMMY",
          raca: "Akita",
          descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes."
        },
        {
          id: 6,
          nome: "HULK",
          raca: "Pit bull",
          descricao: "Uma canina alegre e companheira, porte M/G. Se da bem com outros caes."
        },
      ],
      model: null,
      search: null,
      tab: null,
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
    }
}
</script>
