<template>
<v-card rounded="xl" class="px-8 pt-8" color="white">
    <v-card-text>
        <v-row>
            <v-col cols="8">
                <div class="d-flex mb-3">
                    <div class="rounded-xl" style="width: 220px; height: 313px; overflow: hidden;">
                    <v-img :src="url" style="object-fit: cover; width: 100%; height: 100%;"></v-img>
                    </div>
                    <div class="text-left ml-8">
                        <p class="text-h4 mb-n2"> {{ title }} </p>
                        <p class="text-h6 mb-2"> {{ author }}</p>
                        <p class="text-body-2" style="color: gray">{{ edition }}</p>
                        <table class="text-body-1 mb-3">
                            <tbody>
                            <tr v-if="seriesName">
                                <td>Series</td>
                                <td>: {{ seriesName }}
                                    <span v-if="seriesNumber"> (#{{ seriesNumber }})</span>
                                </td>
                            </tr>
                            <tr>
                                <td>Publication Date</td>
                                <td>: {{ publicationDate }}</td>
                            </tr>
                            <tr>
                                <td>Pages</td>
                                <td>: {{ page }}</td>
                            </tr>
                            </tbody>
                        </table>
                        <p class="text-body-1 mb-n2">Price</p>
                        <p class="text-h6 mb-3">Rp. 500.000</p>
                        <!-- <v-btn rounded="lg" style="float: left;" color="primary">
                            Add to Cart
                        </v-btn> -->
                        <div v-if="isInCollection">
                            <RouterLink :to="'/book/' + id + '/read'">
                                <v-btn rounded="lg" style="float: left; position: relative;" color="primary">
                                    Read
                                </v-btn>
                            </RouterLink>
                        </div>
                        <div v-else>
                            <AddToCartButton v-if="!isBookInCart" :bookId="id" @add="switchButton">
                                Add to Cart
                            </AddToCartButton>
                            <RemoveFromCartButton v-else :bookId="id" @remove="switchButton">
                                Remove from Cart
                            </RemoveFromCartButton>
                        </div>
                    </div>
                </div>
                <p class="text-h6 text-left mb-2">Overview</p>
                <p class="text-body-1 text-left">
                    {{ summary }}
                </p>
            </v-col>
            <v-col class="d-flex flex-column align-center">
                <p class="text-body-1 mb-2">You May Also Like</p>
                <BookItem 
                    class="mb-3" v-for="book in recommendation" :key="book.id" 
                    :id="book.id"
                    :author="book.author" 
                    :title="book.title" 
                    :thumbnailUrl="book.thumbnailUrl"
                />
            </v-col>
        </v-row>
    </v-card-text>
</v-card>
</template>   
        
    <script lang="js">
    import { defineComponent } from 'vue';
    import BookItem from '@/components/BookItem.vue'
    import AddToCartButton from '@/components/AddToCartButton.vue'
    import RemoveFromCartButton from '@/components/RemoveFromCartButton.vue'
    
    export default defineComponent({
        name: 'BookDetailContainer',
        components: {
            BookItem,
            AddToCartButton,
            RemoveFromCartButton
        },
        data() {
            return {
                isBookInCart: false,
                url: ""
            }
        },
        created() {
            this.loadData()
        },
        props: {
            id: {
                type: String,
                required: true
            },
            title: {
                type: String,
                required: true
            },
            author: {
                type: String,
                required: true
            },
            publicationDate: {
                type: String,
            },
            page: {
                type: String,
            },
            summary: {
                type: String,
            },
            edition: {
                type: String,
            },
            seriesName: {
                type: String
            },
            seriesNumber: {
                type: String
            },
            imageSrc: {
                type: String
            },
            recommendation: {
                type: Array
            },
            isInCart: {
                type: Boolean,
            },
            isInCollection: {
                type: Boolean,
            }
        },
        watch: {
            isInCart: {
                immediate: true,
                handler(value) {
                    this.isBookInCart = value;
                }
            },
            '$route': 'loadData'
        },
        methods: {
            switchButton() {
                this.isBookInCart = !this.isBookInCart;
            },
            loadData() {
                this.url = process.env.VUE_APP_BASEURL + this.imageSrc
            }
        }
    });
    </script>
    
    <style scoped>

    </style>
        