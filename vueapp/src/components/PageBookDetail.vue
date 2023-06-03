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
                        <SideBar />
                    </v-col>
                    <v-col cols="10">
                        <BookDetailContainer 
                            :id="this.$route.params.id"
                            :title="post.book.title"
                            :author="post.book.author"
                            :edition="post.book.edition"
                            :publicationDate="post.book.publicationDate"
                            :page="post.book.page"
                            :summary="post.book.summary"
                            :seriesName="post.book.seriesName"
                            :seriesNumber="post.book.seriesNumber"
                            :imageSrc="post.book.imageUrl"
                            :recommendation="post.recommendation.books"
                            :isInCart="isInCart"
                            :isInCollection="isInCollection"
                        />
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
    import GeneralContainer from '@/components/GeneralContainer.vue'
    import BookDetailContainer from '@/components/BookDetailContainer.vue'

    export default defineComponent({
        name: 'PageBookDetail',
        components: {
            LoadingBar,
            NavigationBar,
            SideBar,
            GeneralContainer,
            BookDetailContainer
        },
        data() {
            return {
                loading: false,
                post: null,
                isInCart: false,
                isInCollection: false
            };
        },
        created() {
            this.fetchData();
        },
        watch: {
            '$route': 'fetchData'
        },
        methods: {
            async fetchData() {
                this.post = null;
                this.loading = true;
                await fetch('/api/book/' + this.$route.params.id)
                    .then(r => r.json())
                    .then(json => {
                        console.log(json);
                        this.post = json;
                        return;
                    });
                const token = localStorage.getItem('token')
                if(token != null) {
                    await fetch('/api/cart/' + this.$route.params.id, {
                        method: 'GET',
                        headers: {
                            Authorization: `Bearer ${localStorage.getItem('token')}`,
                            'Content-Type': 'application/json',
                        },
                    })
                    .then(response => {
                        console.log(response);

                        return response.json();
                    })
                    .then(data => {
                        this.isInCart = data.book != null;
                    })

                    await fetch('/api/collection/' + this.$route.params.id, {
                        method: 'GET',
                        headers: {
                            Authorization: `Bearer ${localStorage.getItem('token')}`,
                            'Content-Type': 'application/json',
                        },
                    })
                    .then(response => {
                        console.log(response);

                        return response.json();
                    })
                    .then(data => {
                        this.isInCollection = data.book != null;
                    })
                }
                this.loading = false;
            },
        },
    });
</script>