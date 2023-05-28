<template>
    <v-card flat class="d-flex" color="transparent">
        <v-row>
            <v-col cols="3" class="pb-12">
                <v-card-title class="font-weight-bold text-start pl-0 pr-0 pt-0">{{ genre }}</v-card-title>
                <v-card-text class="text-start pl-0 pr-0">
                    {{ genreDescription }} 
                </v-card-text>
                <v-btn rounded="lg" style="float: left;" color="primary">
                    More
                </v-btn>
            </v-col>
            <v-col>
                <v-sheet
                    color="transparent"
                    max-width="620"
                >
                    <v-slide-group
                        v-model="model"
                        show-arrows
                    >
                        <v-slide-group-item
                            v-for="book in books"
                            :key="book.id"
                        >
                            <BookItem
                                :id="book.id"
                                :title="book.title" 
                                :author="book.author" class="mx-5" 
                                :thumbnailUrl="book.thumbnailUrl" 
                            />
                        </v-slide-group-item>
                    </v-slide-group>
                </v-sheet>
            </v-col>
        </v-row>
    </v-card>
</template>   
    
<script lang="js">
import { defineComponent } from 'vue';
import BookItem from '@/components/BookItem.vue'

export default defineComponent({
    name: 'BookSection',
    data: () => ({
      model: null,
    }),
    props: {
        genre: {
            type: String,
            required: true
        },
        genreDescription: {
            type: String,
            required: false
        },
        books: {
            type: Array,
            required: true
        }
    },
    components: {
        BookItem,
    }
});
</script>
    