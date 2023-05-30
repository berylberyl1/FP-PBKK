<template>
<v-card rounded="xl" class="px-8 pt-8" color="white">
    <VCardTitle class="text-start text-h4 mb-3">
        My Cart
    </VCardTitle>
    <v-card-text>
        <table v-if="cart" style="width: 100%;">
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
    }
});
</script>

<style scoped>
tr {
    display: flex;
    justify-content: space-between;
}
</style>
        