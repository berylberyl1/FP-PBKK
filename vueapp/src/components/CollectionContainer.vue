<template>
<v-card rounded="xl" class="px-8 pt-8" color="white">
    <VCardTitle class="text-start text-h4 mb-3">
        My Collection
    </VCardTitle>
    <v-card-text>
        <div v-if="collection" class="d-flex flex-wrap">
            <BookItem 
                v-for="book in collection.books" 
                :key="book.id" 
                :id="book.id"
                :title="book.title" 
                :author="book.author" class="mx-1 mb-4" 
                :thumbnailUrl="book.thumbnailUrl" 
            />
        </div>
        <p class="text-start mb-4" v-else>There is no item in the collection.</p>
    </v-card-text>
</v-card>
</template>   
        
<script lang="js">
import { defineComponent } from 'vue';
import BookItem from '@/components/BookItem.vue'

export default defineComponent({
    name: 'CollectionContainer',
    components: {
        BookItem
    },
    props: {
        collection: {
            type: Object,
            required: true
        }
    },
});
</script>
        