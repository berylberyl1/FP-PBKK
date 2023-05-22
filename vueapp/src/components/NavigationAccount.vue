<template>
    <a class="d-flex ml-4 align-center">
        <div style="width: 45px; height: 45px;">
            <v-img 
                :src="require('@/assets/images/avatar.png')" 
                max-height="45" 
                max-width="45"
                style="border-radius: 50%"
            ></v-img>
        </div>
        <p class="ml-3">{{ fullName }}</p>
        <v-icon class="ml-1">mdi-chevron-down</v-icon>
    </a>
</template>   
    
<script lang="js">
import jwtDecode from 'jwt-decode';

export default {
    name: 'NavigationAccount',
    data: () => ({
        fullName: "Adam Garibald"
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
        }
    }
};
</script>
    