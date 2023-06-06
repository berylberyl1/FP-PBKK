<template>
    <NavigationBar />
    <GeneralContainer>
        <v-row>
            <v-col cols="12">
                <ReadContainer :book-url="'/api/book/' + this.$route.params.id + '/read/file.epub'" />
            </v-col>
        </v-row>
    </GeneralContainer>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import NavigationBar from '@/components/NavigationBar.vue'
    import GeneralContainer from '@/components/GeneralContainer.vue'
    import ReadContainer from '@/components/ReadContainer.vue'

    export default defineComponent({
        name: 'PageRead',
        components: {
            NavigationBar,
            GeneralContainer,
            ReadContainer
        },
    });
</script>