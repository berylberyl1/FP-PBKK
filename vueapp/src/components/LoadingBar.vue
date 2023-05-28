<template>
    <div class="loading">
        <v-progress-circular indeterminate :size="128" :width="12"></v-progress-circular>
    </div>
</template>

<script>
    import { defineComponent } from 'vue';
    export default defineComponent({
        name: "LoadingBar"
    })
</script>

<style scoped>
    .loading {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
    }
</style>