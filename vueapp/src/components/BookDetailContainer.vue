<template>
    <v-card rounded="xl" class="px-8 pt-8" color="white">
        <v-card-text>
            <v-row>
                <v-col cols="8">
                    <div class="d-flex mb-3">
                        <div class="rounded-xl" style="width: 220px; height: 313px; overflow: hidden;">
                        <v-img :src="require('@/assets/images/book-thumbnail.png')" style="object-fit: cover; width: 100%; height: 100%;"></v-img>
                        </div>
                        <div class="text-left ml-8">
                            <p class="text-h4 mb-n2">Title</p>
                            <p class="text-h6 mb-2">by Author</p>
                            <p class="text-body-2" style="color: gray">Hardcover</p>
                            <table class="text-body-1 mb-3">
                                <tbody>
                                <tr>
                                    <td>ISBN</td>
                                    <td>: 0000000001</td>
                                </tr>
                                <tr>
                                    <td>Publisher</td>
                                    <td>: Publisher Name</td>
                                </tr>
                                <tr>
                                    <td>Publication Date</td>
                                    <td>: DD/MM/YYYY</td>
                                </tr>
                                <tr>
                                    <td>Pages</td>
                                    <td>: 100</td>
                                </tr>
                                <tr>
                                    <td>Product Dimension</td>
                                    <td>: w x h x d</td>
                                </tr>
                                </tbody>
                            </table>
                            <p class="text-body-1 mb-n2">Price</p>
                            <p class="text-h6 mb-3">Rp. 500.000</p>
                            <v-btn rounded="lg" style="float: left;" color="primary">
                                Add to Cart
                            </v-btn>
                        </div>
                    </div>
                    <p class="text-h6 text-left mb-2">Overview</p>
                    <p class="text-body-1 text-left">
                        Lorem ipsum dolor sit amet consectetur. Risus rutrum risus est amet. Massa tincidunt 
                        a est nisi non et nisl. Scelerisque quis nisl cras ut nisl. Gravida auctor aliquam 
                        arcu sapien proin. Amet aliquam quam fringilla elit malesuada vestibulum nunc nec leo. 
                        Nulla enim commodo urna feugiat nullam arcu aenean. Pellentesque aliquet amet mus ipsum 
                        bibendum sed. Cursus morbi mauris nulla eget viverra volutpat purus facilisis. Mattis 
                        ac orci vitae ut. Mus et urna aliquet vitae orci iaculis sed viverra. Tempor sed 
                        sagittis ligula sollicitudin vulputate quam tellus felis risus. Lectus aliquam enim 
                        egestas massa duis. Integer dui eget bibendum eu id. Sit interdum facilisi eu integer lobortis 
                        enim. Mauris sed aliquam habitant lobortis.
                    </p>
                </v-col>
                <v-col class="d-flex flex-column align-center">
                    <p class="text-body-1 mb-2">You May Also Like</p>
                    <BookItem class="mb-3" v-for="i in 3" :key="i" author="author" title="title" />
                </v-col>
            </v-row>
        </v-card-text>
    </v-card>
    </template>   
        
    <script lang="js">
    import { defineComponent } from 'vue';
    import BookItem from '@/components/BookItem.vue'
    
    export default defineComponent({
        name: 'BookDetailContainer',
        components: {
            BookItem
        }
    });
    </script>
    
    <style scoped>

    </style>
        