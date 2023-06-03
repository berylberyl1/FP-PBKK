<template>
<v-card style="position: fixed;" flat color="transparent">
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
                <router-link v-for="item in items" :key="item.id" :to="item.to" class="list" style="text-decoration: none;" >
                    <v-list-item v-if="item.show" rounded="lg" class="mb-2 text-start" :prepend-icon="item.prependIcon" :title="item.name" :value="item.id" :active="item.active"></v-list-item>
                </router-link>
            </v-list>
        </v-navigation-drawer>
        <v-main style="height: 250px"></v-main>
    </v-layout>
</v-card>
</template> 
    
<script lang="js">
export default {
    name: 'SideBar',
    created() {
        this.setActive();
        this.setShow();
    },
    data() {
        return {
            items: [
                { id: 1, to: "/", name: 'Home', prependIcon: 'mdi-home', active: false, show: true },
                { id: 2, to: "/collection", name: 'Collection', prependIcon: "mdi-forum", active: false, show: true },
            ],
        };
    },
    props: {
        active: {
            type: Number,
        }
    },
    methods: {
        setActive() {
            this.items.forEach(item => {
                if(item.id == this.active) {
                    item.active = true;
                }
                else {
                    item.active = false;
                }
            })
        },
        setShow() {
            if(!this.hasValidToken()) {
                this.items[1].show = false;
            }
        },
        hasValidToken() {
            const token = localStorage.getItem('token');
            let tokenIsValid = true;
            
            if(token == null) {
                tokenIsValid = false;
            }

            return tokenIsValid;
        }
    }
};
</script>

<style scoped>
.list {
    color: black;
}

.list-active {
    background-color: black;
    color: #F8F2EE;
}
</style>