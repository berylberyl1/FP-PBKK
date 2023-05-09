<template>
<v-tabs
    selected-class="tab-active"
    hide-slider
    mandatory
    v-model="tab"
    class="mb-5"
>
    <v-tab rounded="lg" value="one">All</v-tab>
    <v-tab rounded="lg" value="two">Fantasy</v-tab>
    <v-tab rounded="lg" value="three">Drama</v-tab>
</v-tabs>
<v-card rounded="xl" class="px-8 pt-8" color="white">
    <v-card-text>
        <v-window v-model="tab">
            <v-window-item value="one">
                <BookSection class="mb-15" />
                <BookSection class="mb-15" />
                <BookSection class="mb-15" />
                <BookSection class="mb-15" />
            </v-window-item>
            <v-window-item value="two">
                <BookSection class="mb-15" />
            </v-window-item>
            <v-window-item value="three">
                <BookSection class="mb-15" />
            </v-window-item>
        </v-window>
    </v-card-text>
</v-card>
</template>   
    
<script lang="js">
import BookSection from '@/components/BookSection.vue'

export default {
    name: 'BookContainer',
    data: () => ({
        tab: null,
        tabActive: 'tab-active'
    }),
    components: {
        BookSection
    },
};
</script>

<style scoped>
.tab-active {
    background-color: #FDA62B;
}
</style>
    