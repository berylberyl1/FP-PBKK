<template>
<v-app-bar app flat color="transparent" extended=60>
    <GeneralContainer>
      <v-row style="padding-top: 60px;">
        <v-col cols="2" class="pl-0">
          <router-link to="/" class="d-flex justify-start align-center" style="color: black; text-decoration: none;">
            <v-img :src="require('@/assets/images/logo.png')" max-height="64" max-width="64"></v-img>
            <v-app-bar-title class="font-weight-bold">
                Book Book
            </v-app-bar-title>
          </router-link>
        </v-col>
        <v-col cols="10" class="d-flex justify-end align-center">
          <SearchBar />
          <NavigationAccount v-if="hasValidToken" />
          <div v-else>
            <router-link to="/login" style="color: black;">
              <v-btn rounded="lg" class="text-none mr-2" variant="outlined">
                Log in
              </v-btn>
            </router-link>
            <router-link to="/signup">
              <v-btn rounded="lg" class="text-none" color="black" variant="flat">
                Sign up
              </v-btn>
            </router-link>
          </div>
        </v-col>
      </v-row> 
    </GeneralContainer>
</v-app-bar>
</template>
  
<script lang="js">
import GeneralContainer from '@/components/GeneralContainer.vue';
import SearchBar from '@/components/SearchBar.vue';
import NavigationAccount from '@/components/NavigationAccount.vue';
import jwtDecode from 'jwt-decode';

export default {
  name: 'NavigationBar',
  components: {
    GeneralContainer,
    SearchBar,
    NavigationAccount
  },
  computed: {
    hasValidToken() {
      const token = localStorage.getItem('token');
      let tokenIsValid = true;
    
      if(token == null) {
        tokenIsValid = false;
      }

      const user = jwtDecode(token);

      if(user == null || user.exp < Date.now() / 1000) {
        localStorage.clear();
        tokenIsValid = false;
      }

      return tokenIsValid;
    }
  },
};
</script>
