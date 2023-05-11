<template>
<v-app :style="cssProps">
  <v-main>
    <NavigationBar />
    <GeneralContainer>
      <v-row>
        <v-col cols="2" class="pl-0">
          <SideBar />
        </v-col>
        <v-col cols="10">
          <BookContainer />
        </v-col>
      </v-row>
    </GeneralContainer>
    <HelloWorld />
  </v-main>
</v-app>
</template>

<script>
import NavigationBar from '@/components/NavigationBar.vue';
import SideBar from '@/components/SideBar.vue';
import BookContainer from '@/components/BookContainer.vue';
import GeneralContainer from '@/components/GeneralContainer.vue';
import HelloWorld from '@/components/HelloWorld.vue';

export default {
  name: 'App',
  components: {
    NavigationBar,
    SideBar,
    BookContainer,
    GeneralContainer,
    HelloWorld,
  },
  computed: {
    cssProps () {
        var themeColors = {}
        Object.keys(this.$vuetify.theme.themes.light).forEach((color) => {
          themeColors[`--v-${color}`] = this.$vuetify.theme.themes.light[color]
        })
        return themeColors
    }
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Manrope&display=swap');

#app {
  font-family: Manrope, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
</style>
