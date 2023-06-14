<template>
    <v-btn rounded="lg" style="float: left;" color="primary" @click="addToCart">
        <slot>
            
        </slot>
    </v-btn>
</template>   
    
<script lang="js">

export default {
    name: 'RemoveFromCartButton',
    methods: {
        async addToCart() {
            var token = localStorage.getItem('token');

            if(token != null) {
                const BASE_URL = process.env.VUE_APP_BASEURL
                console.log(BASE_URL + '/api/cart/remove/' + this.bookId);
                await fetch(BASE_URL + '/api/cart/remove/' + this.bookId, {
                    method: 'POST',
                    headers: {
                        Authorization: `Bearer ${token}`,
                        'Content-Type': 'application/json',
                    },
                })
                .then(response => {
                    if(response.ok) {
                        console.log(response.json());
                        this.$emit("remove");
                    }
                });
            }
            else {
                this.$router.push('/login');
            }
        }
    },
    props: {
        bookId: {
            type: String,
            required: true
        }
    }
};
</script>
    