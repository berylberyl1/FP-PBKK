<template>
<v-card rounded="xl" class="px-8 pt-8" color="white">
    <VCardTitle class="text-start text-h4 mb-3">
        My Cart
    </VCardTitle>
    <v-card-text>
        <div v-if="cart">
            <table style="width: 100%;">
                <thead>
                    <tr>
                        <td>Product</td>
                        <td>Subtotal</td>
                    </tr>
                </thead>
                <tbody>
                    <div v-for="book in cart.books" :key="book.id">
                        <v-divider></v-divider>
                        <tr>
                            <td>
                                <BookItem 
                                    :id="book.id"
                                    :title="book.title" 
                                    :author="book.author" class="mx-5" 
                                    :thumbnailUrl="book.thumbnailUrl" 
                                    horizontal
                                />
                            </td>
                            <td class="pt-3">
                                Rp. 500.000
                            </td>
                        </tr>
                    </div>
                </tbody>
            </table>
            <div class="d-flex justify-space-between">
                <p class="text-h5">
                    Total
                </p>
                <div class="mb-6">
                    <p class="text-h5 mb-2">
                        Rp. -
                    </p>
                    <v-btn rounded="lg" style="float: right;" color="primary" @click="checkout">
                        Checkout
                    </v-btn>
                </div>
            </div>
        </div>
        <p class="text-start mb-4" v-else>There is no item in the cart.</p>
    </v-card-text>
</v-card>
</template>   
        
<script lang="js">
import { defineComponent } from 'vue';
import BookItem from '@/components/BookItem.vue'

export default defineComponent({
    name: 'CartContainer',
    components: {
        BookItem
    },
    props: {
        cart: {
            type: Object,
            required: true
        }
    },
    methods: {
        async checkout() {
            var token = localStorage.getItem('token');

            if(token != null) {
                await fetch('/api/cart/checkout', {
                    method: 'POST',
                    headers: {
                        Authorization: `Bearer ${token}`,
                        'Content-Type': 'application/json',
                    },
                })
                .then(response => {
                    if(response.ok) {
                        console.log(response);
                    }
                });
            }
            else {
                this.$router.push('/login');
            }
            this.$router.push('/');
        }
    },
});
</script>

<style scoped>
tr {
    display: flex;
    justify-content: space-between;
}
</style>
        