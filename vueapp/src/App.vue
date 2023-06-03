<template>
<v-app :style="cssProps">
  <v-main>
    <router-view></router-view>
  </v-main>
</v-app>
</template>

<script>
import jwtDecode from 'jwt-decode';

export default {
  name: 'App',
  created() {
    this.hasValidToken();
  },
  computed: {
    cssProps () {
        var themeColors = {}
        Object.keys(this.$vuetify.theme.themes.light).forEach((color) => {
          themeColors[`--v-${color}`] = this.$vuetify.theme.themes.light[color]
        })
        return themeColors
    }
  },
  methods: {
    hasValidToken() {
      const token = localStorage.getItem('token');
      let tokenIsValid = true;
    
      if(token == null) {
        tokenIsValid = false;
      }
      else {
        const user = jwtDecode(token);
        if(user == null || user.exp < Date.now() / 1000) {
          localStorage.clear();
          tokenIsValid = false;
        }
      }

      return tokenIsValid;
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
