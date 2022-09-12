<template>
    <v-container fluid>

        <v-row class="" dense>
            <v-col lg="4" xs="6" v-for="item in list" :key="item.id">
                <v-card class="mx-auto mb-8" max-width="300" outlined>
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

                        <v-list-item-avatar tile size="80">
                            <img :src="getFotoUrl(item.foto)" />
                        </v-list-item-avatar>
                    </v-list-item>

                    <v-card-actions>
                        <v-btn v-if="habilitaEditar" color="red lighten-2" text
                            @click="$router.push({name: 'petEdit', params: { id: item.id }})">
                            EDITAR
                        </v-btn>
                        <v-spacer></v-spacer>
                        <v-btn color="red lighten-2" text @click="openDetails(item, 'DETALHES')">
                            DETALHES
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-col>

            <v-col v-if="isLoading" lg="12" xs="12">
                <h5>Carregando informações...</h5>
            </v-col>

            <v-col v-if="!isLoading && list.length == 0" lg="12" xs="12">
                <h5>Nenhum pet para listar</h5>
            </v-col>
        </v-row>



        <v-dialog v-model="openDialogDetails" v-if="openDialogDetails" persistent max-width="791px">
            <v-card>
                <v-btn icon @click="openDialogDetails = false">
                    <v-icon>mdi-close</v-icon>
                </v-btn>
                <v-card-text class="pb-0">
                    <v-container class="pb-0">
                        <v-row>
                            <v-col cols="6">
                                <div style="height:321px; width: 274px;">
                                    <img :src="getFotoUrl(itensDetails.foto)" style="width: 100%;" />
                                </div>
                            </v-col>
                            <v-col cols="6">
                                <div>
                                    Nome
                                    <p>{{itensDetails.nome}}</p>
                                </div>
                                <v-row>
                                    <v-col cols="4">
                                        Raça
                                        <p>{{itensDetails.raca}}</p>
                                    </v-col>
                                    <v-col cols="4">
                                        Peso
                                        <p>{{itensDetails.peso}} Kg</p>
                                    </v-col>
                                    <v-col cols="4">
                                        Idade
                                        <p>{{itensDetails.idade}} meses</p>
                                    </v-col>
                                </v-row>

                                <div>
                                    Localização
                                    <p>{{itensDetails.localizacao}}</p>
                                </div>
                            </v-col>
                        </v-row>
                    </v-container>
                </v-card-text>
                <v-card-actions>

                    <div class="ml-4" style="width: 288px;">
                        <p class="mb-0">Sobre</p>
                        <p>{{itensDetails.descricao}}</p>
                    </div>
                    <v-spacer></v-spacer>

                    <v-btn v-if="habilitaAdotar" color="blue darken-1" text @click="loginTutor()">
                        Quero adotar agora
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>

    </v-container>
</template>
  
<script>
export default {
    name: 'ListaAnimaisComponent',
    components: {},
    props: {
        list: {
            type: Array
        },
        habilitaEditar: {
            type: Boolean,
            default: false
        },
        habilitaAdotar: {
            type: Boolean,
            default: false
        },
        isLoading: {
            type: Boolean,
            default: true
        }
    },
    data: () => ({
        tab: null,
        openDialogDetails: false,
        openDialogEditDetails: false
    }),
    methods: {
        openDetails(item, tipo) {
            this.itensDetails = item
            tipo === 'DETALHES' ?
                this.openDialogDetails = true :
                this.openDialogEditDetails = true;
        },
        getFotoUrl(foto) {
            return `${process.env.VUE_APP_APIURL}api/pets/foto?foto=${foto}`
        }
    }
}
</script>
  