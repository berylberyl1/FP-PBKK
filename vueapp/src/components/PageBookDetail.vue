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
                        <BookDetailContainer 
                            :title="post.title"
                            :author="post.author"
                            :edition="post.edition"
                            :publicationDate="post.publicationDate"
                            :page="post.page"
                            :summary="post.summary"
                            :seriesName="post.seriesName"
                            :seriesNumber="post.seriesNumber"
                            :imageSrc="post.imageUrl"
                        />
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
    import GeneralContainer from '@/components/GeneralContainer.vue'
    import BookDetailContainer from '@/components/BookDetailContainer.vue'

    export default defineComponent({
        name: 'PageBookDetail',
        components: {
            NavigationBar,
            SideBar,
            GeneralContainer,
            BookDetailContainer
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
                fetch('/api/book/' + this.$route.params.id)
                    .then(r => r.json())
                    .then(json => {
                        console.log(json);
                        this.post = json;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>