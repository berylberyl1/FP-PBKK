<template>
<v-card rounded="xl" class="px-8 pt-8" color="white">
    <VCardTitle class="text-start text-h4 mb-3">
        My Cart
    </VCardTitle>
    <v-card-text>
        <table style="width: 100%;">
            <thead>
                <tr>
                    <td>Product</td>
                    <td>Subtotal</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        Test1
                    </td>
                    <td>
                        Test2
                    </td>
                </tr>
            </tbody>
        </table>
    </v-card-text>
</v-card>
</template>   
        
<script lang="js">
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'CartContainer',
});
</script>

<style scoped>
tr {
    display: flex;
    justify-content: space-between;
}
</style>
        