<template>
<v-tabs
    selected-class="tab-active"
    hide-slider
    mandatory
    v-model="tab"
    class="mb-5"
>
    <v-tab rounded="lg" value="all">All</v-tab>
    <v-tab v-for="genre in genres" :key="genre.genre" rounded="lg" :value="genre.genre">
        {{ genre.genre }}
    </v-tab>
</v-tabs>
<v-card rounded="xl" class="px-8 pt-8" color="white">
    <v-card-text>
        <v-window v-model="tab">
            <v-window-item value="all">
                <BookSection v-for="genre in genres" :key="genre.genre" class="mb-15" :books="bookSection[genre.genre]" :genre="genre.genre" />
            </v-window-item>
            <v-window-item v-for="genre in genres" :key="genre.genre" :value="genre.genre">
                <BookSection class="mb-15" :books="bookSection[genre.genre]" :genre="genre.genre" />
            </v-window-item>
        </v-window>
    </v-card-text>
</v-card>
</template>   
    
<script lang="js">
import { defineComponent } from 'vue';
import BookSection from '@/components/BookSection.vue'

export default defineComponent({
    name: 'BookContainer',
    data: () => ({
        tab: null,
        tabActive: 'tab-active',
        bookSection: []
    }),
    props: {
        genres: {
            type: Array,
            required: true
        },
        books: {
            type: Array,
            required: true
        }
    },
    created() {
        this.getBookSectionData();
    },
    methods: {
        getBookSectionData() {
            this.genres.forEach(genre => {
                this.books.forEach(booksFromGenre => {
                    if(booksFromGenre.genre == genre.genre) {
                        this.bookSection[genre.genre] = booksFromGenre.books;
                    }
                })
            })
        }
    },
    components: {
        BookSection
    },
});
</script>

<style scoped>
.tab-active {
    background-color: #FDA62B;
}
</style>
    