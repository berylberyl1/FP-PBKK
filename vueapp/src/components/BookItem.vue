<template>
    <v-card flat width="111" class="d-flex flex-column" color="transparent">
        <div max-width="111" max-height="156">
            <v-img class="rounded-lg" :src="require('@/assets/images/book-thumbnail.png')"></v-img>
        </div>
        <v-card-title class="text-start pl-0 pb-0">Title</v-card-title>
        <v-card-subtitle class="text-start pl-0">Author</v-card-subtitle>
    </v-card>
</template>   
    
<script lang="js">
export default {
    name: 'BookItem',
};
</script>
    