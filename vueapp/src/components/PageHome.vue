<template>
    <div class="post">
        <div v-if="loading" class="loading">
            <LoadingBar />
        </div>

        <div v-if="post" class="content">
            <NavigationBar />
            <GeneralContainer>
                <v-row>
                    <v-col cols="2" class="pl-0">
                        <SideBar class="mt-15" active="1" />
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
    import LoadingBar from '@/components/LoadingBar.vue'
    import NavigationBar from '@/components/NavigationBar.vue'
    import SideBar from '@/components/SideBar.vue'
    import BookContainer from '@/components/BookContainer.vue'
    import GeneralContainer from '@/components/GeneralContainer.vue'

    export default defineComponent({
        components: {
            LoadingBar,
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

                const BASE_URL = process.env.VUE_APP_BASEURL
                fetch(BASE_URL + '/api/home')
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

