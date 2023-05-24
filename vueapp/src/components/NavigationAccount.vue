<template>
    <v-menu
        v-model="menu"
        open-on-hover
        :close-on-content-click="false"
    >
        <template v-slot:activator="{ props }">
            <span
            v-bind="props"
            class="d-flex ml-4 align-center pb-3"
            >
                <v-avatar size="45">
                    <v-img 
                        :src="require('@/assets/images/avatar.png')" 
                    ></v-img>
                </v-avatar>
                <p class="ml-3">{{ fullName }}</p>
                <v-icon class="ml-1">mdi-chevron-down</v-icon>
            </span>
        </template>
        <v-card min-width="250" max-width="350" class="pa-1">
            <v-list>
                <v-list-item>
                    <div class="d-flex align-center">
                        <v-avatar size="64">
                            <v-img :src="require('@/assets/images/avatar.png')" ></v-img>
                        </v-avatar>
                        <div class="d-flex flex-column ml-3">
                            <p class="text-body-1 font-weight-bold">{{ fullName }}</p>
                            <p class="text-body-2">{{ email }}</p>
                        </div>
                    </div>
                </v-list-item>
            </v-list>

            <v-divider></v-divider>

            <v-list>
                <v-list-item>            
                    <div class="d-flex flex-column">
                        <v-btn class="text-none" @click="logout">
                            Log out
                        </v-btn>
                    </div>
                </v-list-item>
            </v-list>

        </v-card>
    </v-menu>
</template>   
    
<script lang="js">
import jwtDecode from 'jwt-decode';

export default {
    name: 'NavigationAccount',
    data: () => ({
        menu: false,
        fullName: "Adam Garibald",
        email: "adamgaribald@gmail.com"
    }),
    created() {
        this.loadToken();
    },
    methods: {
        loadToken() {
            const token = localStorage.getItem('token');
            if(token == null) {
                return;
            }
            const user = jwtDecode(token);
            console.log(user.exp + " " + Date.now() / 1000);
            this.fullName = user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
            this.email = user["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];
        },
        logout() {
            localStorage.clear();
            window.location.reload();
        }
    }
};
</script>
    