<template>
    <v-card flat width="130" class="d-flex flex-column" color="transparent">
        <div style="width: 111px; height: 156px; overflow: hidden;">
            <v-img class="rounded-lg" :src="thumbnailSrc" style="object-fit: cover; width: 100%; height: 100%;"></v-img>
        </div>
        <v-card-title class="text-start pl-0 pb-0 text-subtitle-1">{{ title }}</v-card-title>
        <v-card-subtitle class="text-start pl-0">{{ author }}</v-card-subtitle>
    </v-card>
</template>   
    
<script lang="js">
import { defineComponent } from 'vue';

export default defineComponent({
    name: 'BookItem',
    data: () => ({
        thumbnailSrc: null
    }),
    beforeUnmount() {
        if (this.thumbnailSrc) {
            URL.revokeObjectURL(this.thumbnailSrc);
        }
    },
    created() {
        this.loadThumbnailData();
    },
    watch: {
        '$route': 'loadThumbnailData'
    },
    props: {
        title: {
            type: String,
            required: true
        },
        author: {
            type: String,
            required: true
        },
        thumbnail: {
            type: String,
            required: true
        },
        thumbnailMime: {
            type: String,
            required: true
        }
    },
    methods: {
        loadThumbnailData() {
            this.thumbnailSrc = `data:${this.thumbnailMime};base64,${this.thumbnail}`;
        },
    },
});
</script>
    