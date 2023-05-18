<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="post" class="content">
            <div v-if="imageDictSrc">
                <img :src="imageDictSrc[0]" alt="Book Image" />
            </div>
            <p> {{ post['randomBooksFromGenre']['books'] }} </p>
            <table>
                <thead>
                    <tr>
                        <th>Genre</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="genre in post['genre']" :key="genre.genre">
                        <td>{{ genre.genre }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                imageDictSrc: [],
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        beforeUnmount() {
            if (this.imageDictSrc) {
                this.imageDictSrc.forEach((imageSrc) => {
                    URL.revokeObjectURL(imageSrc);
                })  
            }
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            loadImageData() {
                this.post['randomBooksFromGenre'][0]['books'].forEach((book) => {
                    this.imageDictSrc[book['id']] = `data:image/png;base64,${book['thumbnail']}`;
                })
            },
            fetchData() {
                this.post = null;
                this.loading = true;

                fetch('home')
                    .then(r => r.json())
                    .then(json => {
                        console.log(json);
                        this.post = json;
                        this.loading = false;
                        this.loadImageData()
                        return;
                    });
            }
        },
    });
</script>