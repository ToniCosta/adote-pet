<template>
    <v-app-bar
    app
    color="white"
    > 
        <v-row>
            <v-col cols="6">          
            </v-col>
            <v-col cols="4">
            <v-tabs>        
                <v-tab class="grey--text" to="/">Home</v-tab>
                <v-tab class="grey--text" to="/sobre">
                Sobre nós
                </v-tab>
                <v-tab class="grey--text" to="/ajuda">Ajuda</v-tab>
                <v-tabs-slider color="redAccent"></v-tabs-slider>
            </v-tabs>
            </v-col>
            <v-col cols="2" class="d-inline-flex">
            <v-btn
                class="ma-1"
                color="grey"
                plain
                @click="openDialogRegister = true"
            >
                Criar Conta
            </v-btn>
            <v-btn
                class="ma-1"
                color="grey"
                plain
                @click="openDialogLogIn = true"
            >
                Entrar
            </v-btn>
            </v-col>
        </v-row>
        <v-dialog
            v-model="openDialogLogIn"
            persistent
            max-width="600px"
        >
            <v-card>
                <v-card-title>
                <p class="text-h5 text-center">
                    Olá! Que bom ter você aqui.<br />
                    Agora você pode acessar a sua conta.
                </p>
                </v-card-title>
                <v-card-text>
                    <v-container>
                        <v-row>
                            <v-col cols="12">
                                <v-text-field
                                label="Email*"
                                required
                                v-model="login.login"
                                ></v-text-field>
                            </v-col>
                            <v-col cols="12">
                                <v-text-field
                                label="Senha*"
                                type="password"
                                v-model="login.senha"
                                required
                                ></v-text-field>
                            </v-col>
                        </v-row>
                    </v-container>
                </v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn
                        color="blue darken-1"
                        text
                        @click="openDialogLogIn = false"
                    >
                        Fechar
                    </v-btn>
                    <v-btn
                        color="blue darken-1"
                        text
                        @click="loginTutor()"
                    >
                        Continuar
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
        <v-dialog
            v-model="openDialogRegister"
            persistent
            max-width="600px"
        >
            <v-card>
                <v-card-title>
                <p class="text-h5 text-center">
                    Olá! Que bom ter você aqui.<br />
                    Agora você pode acessar a sua conta.
                </p>
                </v-card-title>
                <v-card-text>
                <v-container>
                    <v-row>
                        <v-col cols="12">
                            <v-text-field
                            label="Email*"
                            required
                            ></v-text-field>
                        </v-col>
                        <v-col
                            cols="6"
                            sm="6"
                            md="4"
                        >
                            <v-text-field
                            label="Nome*"
                            required
                            ></v-text-field>
                        </v-col>
                        <v-col
                            cols="6"
                            sm="6"
                            md="4"
                        >
                            <v-text-field
                            label="Sobrenome"
                            ></v-text-field>
                        </v-col>
                        <v-col
                            cols="12"
                            sm="6"
                            md="4"
                        >
                            <v-text-field
                            label="Celular"
                            required
                            ></v-text-field>
                        </v-col>
                    
                        <v-col cols="12">
                            <v-text-field
                            label="Senha*"
                            type="password"
                            required
                            ></v-text-field>
                        </v-col>
                    </v-row>
                </v-container>
                <small>*campos obrigatórios</small>
                </v-card-text>
                <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn
                    color="blue darken-1"
                    text
                    @click="openDialogRegister = false"
                >
                    Fechar
                </v-btn>
                <v-btn
                    color="blue darken-1"
                    text
                    @click="openDialogRegister = false"
                >
                    Registrar
                </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-app-bar>
            
</template>
<script>
import { fazerLogin } from '../services/accountService.js'
export default {
    data: () => ({
        openDialogRegister: false,
        openDialogLogIn: false,
        login: {
            login: '',
            senha: ''
        }
    }),
    methods: {
        loginTutor() {
            fazerLogin(this.login.login, this.login.senha).then(({data}) => {
                console.log(data)
            })
        }
    }
}
</script>