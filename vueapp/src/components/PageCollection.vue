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
                        <SideBar active="2" />
                    </v-col>
                    <v-col cols="10">
                        <CollectionContainer :collection="post.collection" />
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
    import CollectionContainer from '@/components/CollectionContainer.vue'

    export default defineComponent({
        name: 'PageCollection',
        components: {
            LoadingBar,
            NavigationBar,
            SideBar,
            GeneralContainer,
            CollectionContainer
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
                fetch(BASE_URL + '/api/collection', {
                    method: 'GET',
                    headers: {
                        Authorization: `Bearer ${localStorage.getItem('token')}`,
                        'Content-Type': 'application/json',
                    },
                })
                .then(response => {
                    console.log(response);

                    if(response.status == "401") {
                        this.$router.push("/");
                    }

                    return response.json();
                })
                .then(data => {
                    console.log(data);
                    this.post = data;
                    this.loading = false;
                })
                .catch(error => {
                    console.error(error);
                });
            },
        },
    });
</script>