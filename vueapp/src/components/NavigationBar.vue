<template>
<v-app-bar app flat color="transparent" extended=60>
    <GeneralContainer>
      <v-row style="padding-top: 60px;">
        <v-col cols="2" class="d-flex justify-start align-center pl-0">
          <v-img :src="require('@/assets/images/logo.png')" max-height="64" max-width="64"></v-img>
          <v-app-bar-title class="font-weight-bold">
              Book Book
          </v-app-bar-title>
        </v-col>
        <v-col cols="10" class="d-flex justify-end align-center">
          <SearchBar />
          <NavigationAccount />
        </v-col>
      </v-row> 
    </GeneralContainer>
</v-app-bar>
</template>
  
<script lang="js">
import GeneralContainer from '@/components/GeneralContainer.vue';
import SearchBar from '@/components/SearchBar.vue';
import NavigationAccount from '@/components/NavigationAccount.vue';

export default {
  name: 'NavigationBar',
  components: {
    GeneralContainer,
    SearchBar,
    NavigationAccount
  }
};
</script>
