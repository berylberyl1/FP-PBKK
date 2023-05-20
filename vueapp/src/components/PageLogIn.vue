<template>
<NavigationBar />
<v-card class="mt-4 mx-auto pa-4" max-width="500" rounded="lg" color="white">
    <v-card-title>
        Log in to your BookBook account
    </v-card-title>
    <v-container>
      <v-text-field
        v-model="email"
        :rules="[rules.required]"
        color="primary"
        label="Email"
        variant="underlined"
      ></v-text-field>

      <v-text-field
        v-model="password"
        :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
        :rules="[rules.required]"
        :type="showPassword ? 'text' : 'password'"
        color="primary"
        label="Password"
        placeholder="Enter your password"
        variant="underlined"
        @click:append="showPassword = !showPassword"
      ></v-text-field>

    </v-container>

    <v-card-actions>
      <v-spacer></v-spacer>

      <v-btn class="px-auto text-none pa-1 px-4" variant="flat" color="primary">
        Log in

        <v-icon icon="mdi-chevron-right" end></v-icon>
      </v-btn>

      <v-spacer></v-spacer>
    </v-card-actions>

    <p class="mt-3 text-subtitle-1">or <router-link to="/login">Forgot Password</router-link></p>

    <v-divider class="my-3"></v-divider>

    <p class="text-subtitle-2">Don't have an account? <router-link to="/signup">Sign up</router-link></p>
</v-card>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import NavigationBar from '@/components/NavigationBar.vue'

export default defineComponent({
    name: 'PageLogIn',
    components: {
        NavigationBar,
    },
    data: () => ({
      email: null,
      password: null,
      showPassword: false,
      rules: {
        required: value => !!value || 'Required.',
      },
    }),
})
</script>