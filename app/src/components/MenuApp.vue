<template>
    <v-app-bar
    app
    color="white"
    > 
        <v-row>
            <v-col 
                lg="6"
                xs="1"
            >          
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

        <dialog-entrar :openDialogLogIn="openDialogLogIn" @close="() => { openDialogLogIn = false}"></dialog-entrar>
        <dialog-create-account :openDialogRegister="openDialogRegister" @close="() => { openDialogRegister = false}"></dialog-create-account>

    </v-app-bar>
            
</template>
<script>
import DialogEntrar from './DialogEntrar.vue'
import DialogCreateAccount from './DialogCreateAccount.vue';
export default {
    components: { 
        DialogEntrar,
        DialogCreateAccount
    },
    data: () => ({
        openDialogRegister: false,
        openDialogLogIn: false,
    }),
    methods: {
    }
}
</script>