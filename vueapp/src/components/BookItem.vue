<template>
    <v-card flat width="130" class="d-flex flex-column" color="transparent">
        <div style="width: 111px; height: 156px; overflow: hidden;">
            <v-img v-if="thumbnailUrl" class="rounded-lg" :src="this.thumbnailUrl" style="object-fit: cover; width: 100%; height: 100%;"></v-img>
            <v-img v-else :src="require('@/assets/images/book-thumbnail.png')" style="object-fit: cover; width: 100%; height: 100%;"></v-img>
        </div>
        <v-card-title class="text-start pl-0 pb-0 ma-0 mb-n2 text-subtitle-1">{{ title }}</v-card-title>
        <v-card-subtitle class="text-start pl-0 pt-0">{{ author }}</v-card-subtitle>
    </v-card>
</template>   
    
<script lang="js">
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'BookItem',
    props: {
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
        thumbnail: {
            type: String,
        },
        thumbnailMime: {
            type: String,
        }
    },
});
</script>
    