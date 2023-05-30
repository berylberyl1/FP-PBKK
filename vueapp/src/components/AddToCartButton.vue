<template>
    <v-btn rounded="lg" style="float: left;" color="primary" @click="addToCart">
        <slot>
            
        </slot>
    </v-btn>
</template>   
    
<script lang="js">

export default {
    name: 'AddToCartButton',
    methods: {
        async addToCart() {
            var token = localStorage.getItem('token');

            if(token != null) {
                console.log('/api/cart/add/' + this.bookId);
                await fetch('/api/cart/add/' + this.bookId, {
                    method: 'POST',
                    headers: {
                        Authorization: `Bearer ${token}`,
                        'Content-Type': 'application/json',
                    },
                })
                .then(response => {
                    console.log(response.json());
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
    