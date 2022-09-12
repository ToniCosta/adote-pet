<template>
    <v-dialog
        v-model="open"
        persistent
        max-width="600px"
    >
        <v-card>
            <v-card-title>
                <v-col cols="12" class="text-h5 text-center">
                    <p class="text-h5 text-center">
                        Olá! Que bom ter você aqui.<br />
                        Agora você pode criar a sua conta.
                    </p>
                </v-col>
            </v-card-title>

            <v-card-text>
            <v-container>

                <div v-if="tipo == ''">
                    <v-row>
                        <v-col cols="12">
                            <v-btn block elevation="6" fab plain rounded @click="() => { tipo = 'T' }" class="mb-3">Quero me cadastrar como um tutor</v-btn>
                            <v-btn block elevation="6" fab plain rounded @click="() => { tipo = 'R' }">Sou um representante de uma ONG ou entidade</v-btn>
                        </v-col>
                    </v-row>
                </div>
                <div v-else>
                    <v-form ref="form" v-model="valid">
                        <v-container>
                            <v-row>
                                <v-col cols="12">
                                <v-text-field
                                v-model="model.email"
                                :rules="[
                                    () => !!model.email || 'Campo obrigatório',
                                    () => /.+@.+\..+/.test(model.email) || 'E-mail deve ser válido'
                                ]"
                                :error-messages="errorMessages"
                                label="Email*"
                                required
                                ></v-text-field>
                            </v-col>
                            <v-col
                                :cols="tipo == 'T' ? 6 : 12"
                                :sm="tipo == 'T' ? 6 : 12"
                                :md="tipo == 'T' ? 4 : 8"
                            >
                                <v-text-field
                                v-model="model.nome"
                                :rules="[() => !!model.nome || 'Campo obrigatório']"
                                :label="tipo == 'T' ? 'Nome*' : 'Razão social*'"
                                required
                                ></v-text-field>
                            </v-col>
                            <v-col
                                v-if="tipo == 'T'"
                                cols="6"
                                sm="6"
                                md="4"
                            >
                                <v-text-field
                                v-model="model.sobrenome"
                                label="Sobrenome"
                                ></v-text-field>
                            </v-col>
                            <v-col
                                cols="12"
                                sm="6"
                                md="4"
                            >
                                <v-text-field
                                v-model="model.celular"
                                label="Celular"
                                required
                                ></v-text-field>
                            </v-col>
                            <v-col cols="12">
                                <v-text-field
                                v-model="model.senha"
                                :rules="[() => !!model.senha || 'Campo obrigatório']"
                                label="Senha*"
                                type="password"
                                required
                                ></v-text-field>
                            </v-col>
                            <v-col cols="12">
                                <v-text-field
                                v-model="model.confirmarSenha"
                                :rules="[
                                    () => !!model.confirmarSenha || 'Campo obrigatório',
                                    () => checkPassword() || 'A confirmação da senha deve ser igual à senha'
                                ]"
                                label="Confirmação de Senha*"
                                type="password"
                                required
                                ></v-text-field>
                            </v-col>

                            </v-row>
                        </v-container>
                    </v-form>
                    <small>*campos obrigatórios</small>
                </div>
            </v-container>
            
            </v-card-text>

            <v-card-actions>
                <v-spacer></v-spacer>
                
                <v-btn
                    color="blue darken-1"
                    text
                    @click="close()"
                >
                    Fechar
                </v-btn>
                <v-btn
                    v-if="tipo != ''"
                    color="blue darken-1"
                    text
                    @click="cadastrar()"
                >
                    Registrar
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
            
</template>
<script>
import { trataErro } from '../services/api.js'
import { criarContaTutor, criarContaRepresentante, registrarTokenUsuario } from '../services/accountService.js'
export default {
    name: 'DialogCreateAccount',
    props: {
        openDialogRegister: {
            type: Boolean,
            default: false
        }
    },
    components: { 
    },
    data() {
        return {
            errorMessages: [],
            tipo: '',
            valid: false,
            model: {
                email: '',
                nome: '',
                sobrenome: '',
                celular: '',
                senha: '',
                confirmarSenha: ''
            }
        };
    },
    computed: {
        open: {
            get() {
                return this.openDialogRegister
            }
        }
    },
    methods: {
        close() {
            this.tipo = '';
            this.$emit('close');
        },
        checkPassword() {
            if (this.model.senha != '' && this.model.confirmarSenha != '') {
                return this.model.senha === this.model.confirmarSenha;
            }
            return true;
        },
        cadastrar() {
            this.$refs.form.validate()
            if(this.valid) {
                let criar = this.tipo == 'T' ? criarContaTutor : criarContaRepresentante;
                criar(this.model).then(({data}) => {
                    registrarTokenUsuario(data)
                    this.$toasted.success('Usuário criado com sucesso')
                    this.$root.$emit('loggedOn', data);
                    this.$emit('close')
                }).catch(error => {
                    trataErro(this, error)
                })
            }
        }
    }
}
</script>