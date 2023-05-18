<template>
<v-card style="position: fixed;" class="mt-15" flat color="transparent">
    <v-layout>
        <v-navigation-drawer
            flat
            floating
            permanent
            color="transparent"
            width="195"
            >
            <v-list
                density="compact"
                nav
                mandatory
                class="pl-0"
                active-class="list-active"

            >
                <v-list-item rounded="lg" class="mb-2 text-start" prepend-icon="mdi-view-dashboard" title="Home" value="home" active></v-list-item>
                <v-list-item rounded="lg" class="mb-2 text-start" prepend-icon="mdi-forum" title="About" value="about"></v-list-item>
            </v-list>
        </v-navigation-drawer>
        <v-main style="height: 250px"></v-main>
    </v-layout>
</v-card>
</template> 
    
<script lang="js">
export default {
    name: 'SideBar',
};
</script>

<style scoped>
.list-active {
    background-color: black;
    color: #F8F2EE;
}
</style>