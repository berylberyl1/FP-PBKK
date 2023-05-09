<template>
    <a class="d-flex ml-4 align-center">
        <div style="width: 45px; height: 45px;">
            <v-img 
                :src="require('@/assets/images/avatar.png')" 
                max-height="45" 
                max-width="45"
                style="border-radius: 50%"
            ></v-img>
        </div>
        <p class="ml-3">Adam Garibald</p>
        <v-icon class="ml-1">mdi-chevron-down</v-icon>
    </a>
</template>   
    
<script lang="js">
export default {
    name: 'NavigationAccount',
};
</script>
    