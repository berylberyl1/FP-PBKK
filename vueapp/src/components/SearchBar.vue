<template>
<v-card
    flat
    color="transparent"
    width="400"
>
    <v-card-text class="rounded-pill">
        <v-text-field
            :loading="loading"
            density="compact"
            variant="solo"
            label="Search"
            append-inner-icon="mdi-magnify"
            rounded="pill"
            single-line
            hide-details
            @click:append-inner="onClick"
        ></v-text-field>
    </v-card-text>
</v-card>
</template>   
  
<script lang="js">
export default {
    name: 'SearchBar',
    data: () => ({
        loaded: false,
        loading: false,
    }),

    methods: {
        onClick () {
            this.loading = true

            setTimeout(() => {
                this.loading = false
                this.loaded = true
            }, 2000)
        },
    },
}
</script>
