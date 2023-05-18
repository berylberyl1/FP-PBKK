<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="post" class="content">
            <NavigationBar />
            <GeneralContainer>
            <v-row>
                <v-col cols="2" class="pl-0">
                <SideBar />
                </v-col>
                <v-col cols="10">
                <BookContainer :genres="post['genre']" :books="post['randomBooksFromGenre']" />
                </v-col>
            </v-row>
            </GeneralContainer>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import NavigationBar from '@/components/NavigationBar.vue'
    import SideBar from '@/components/SideBar.vue'
    import BookContainer from '@/components/BookContainer.vue'
    import GeneralContainer from '@/components/GeneralContainer.vue'

    export default defineComponent({
        components: {
            NavigationBar,
            SideBar,
            BookContainer,
            GeneralContainer,
        },
        data() {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            this.fetchData();
        },
        watch: {
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.post = null;
                this.loading = true;

                fetch('home')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>