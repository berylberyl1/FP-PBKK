<template>
    <router-link :to="'/book/' + id" style="color: black; text-decoration: none;">
        <v-card v-if="horizontal" flat class="book-item d-flex" color="transparent">
            <div style="width: 111px; height: 156px; overflow: hidden;">
                <v-img v-if="thumbnailUrl" class="rounded-lg" :src="url" style="object-fit: cover; width: 100%; height: 100%;"></v-img>
                <v-img v-else :src="require('@/assets/images/book-thumbnail.png')" style="object-fit: cover; width: 100%; height: 100%;"></v-img>
            </div>
            <div>
                <v-card-title class="text-start pl-3 pt-0 mt-0 pb-0 ma-0 mb-n2 text-subtitle-1">{{ title }}</v-card-title>
                <v-card-subtitle class="text-start pl-3 pt-0">{{ author }}</v-card-subtitle>
            </div>
        </v-card>
        <v-card v-else flat width="130" class="book-item d-flex flex-column" color="transparent">
            <div style="width: 111px; height: 156px; overflow: hidden;">
                <v-img v-if="thumbnailUrl" class="rounded-lg" :src="url" style="object-fit: cover; width: 100%; height: 100%;"></v-img>
                <v-img v-else :src="require('@/assets/images/book-thumbnail.png')" style="object-fit: cover; width: 100%; height: 100%;"></v-img>
            </div>
            <div>
                <v-card-title class="text-start pl-0 pb-0 ma-0 mb-n2 text-subtitle-1">{{ title }}</v-card-title>
                <v-card-subtitle class="text-start pl-0 pt-0">{{ author }}</v-card-subtitle>
            </div>
        </v-card>
    </router-link>
</template>   
    
<script lang="js">
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'BookItem',
    data() {
        return {
            url: ""
        };
    },
    created() {
        this.loadData()
    },
    methods: {
        loadData() {
            this.url = process.env.VUE_APP_BASEURL + this.thumbnailUrl
        }
    },
    watch: {
        '$route': 'loadData'
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
        thumbnailUrl: {
            type: String,
        },
        horizontal: {
            type: Boolean
        }
    },
});
</script>

<style scoped>
    .book-item {
        transition: transform 0.3s ease;
    }
    .book-item:hover {
        transform: scale(1.05);
    }
</style>