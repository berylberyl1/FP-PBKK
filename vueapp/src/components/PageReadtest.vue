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
                        <ReadTest :collection="post.collection" />
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
    import ReadTest from '@/components/ReadTest.vue'

    export default defineComponent({
        name: 'PageCollection',
        components: {
            LoadingBar,
            NavigationBar,
            SideBar,
            GeneralContainer,
            ReadTest
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

                fetch('/api/collection', {
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