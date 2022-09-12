<template>
    <v-dialog
        v-model="open"
        persistent
        max-width="600px"
    >
        <v-card>

            <v-card-title>
                <v-col cols="12" class="text-h5 text-center">
                Olá! Que bom ter você aqui.<br />
                Agora você pode acessar a sua conta.
                </v-col>
            </v-card-title>

            <v-card-text>
                <v-container>
                    <v-row>
                        <v-col cols="12">
                            <v-text-field
                            label="Email*"
                            required
                            v-model="login.email"
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
                    @click="$emit('close')"
                >
                    Fechar
                </v-btn>
                <v-btn
                    color="blue darken-1"
                    text
                    @click="entrar()"
                >
                    Continuar
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog> 
</template>

<script>
import { fazerLogin, registrarTokenUsuario } from '../services/accountService.js'
export default {
    name: 'DialogEntrar',
    props: {
        openDialogLogIn: {
            type: Boolean,
            default: false
        }
    },
    data: () => ({
        login: {
            email: '',
            senha: ''
        }
    }),
    computed: {
        open: {
            get() {
                return this.openDialogLogIn
            }
        }
    },
    methods: {
        entrar() {
            fazerLogin(this.login.email, this.login.senha).then(({data}) => {
                registrarTokenUsuario(data)
                this.$toasted.success('Login realizado com sucesso')
                this.$root.$emit('loggedOn', data);
                this.$emit('close')
            }).catch(error => {
                console.log(error)
                if (error.response && error.response.data) {
                    this.$toasted.error(error.response.data)
                } else {
                    this.$toasted.error(error)
                }
            })
        }
    }
}
</script>