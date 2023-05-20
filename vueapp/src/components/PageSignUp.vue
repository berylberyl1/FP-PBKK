<template>
<NavigationBar />
<v-card class="mt-4 mx-auto pa-4" max-width="500" rounded="lg">
    <v-card-title>
        Sign up and start reading
    </v-card-title>
    <v-container>
      <v-text-field
        v-model="fullName"
        :rules="[rules.required]"
        color="primary"
        label="Full name"
        variant="underlined"
      ></v-text-field>

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
        :rules="[rules.required, rules.min]"
        :type="showPassword ? 'text' : 'password'"
        color="primary"
        label="Password"
        hint="At least 8 characters"
        placeholder="Enter your password"
        variant="underlined"
        @click:append="showPassword = !showPassword"
      ></v-text-field>

      <v-checkbox
        v-model="terms"
        color="secondary"
        label="I agree to site terms and conditions"
      ></v-checkbox>
    </v-container>

    <v-divider></v-divider>

    <v-card-actions>
      <v-spacer></v-spacer>

      <v-btn background-color="primary" color="success">
        Complete Registration

        <v-icon icon="mdi-chevron-right" end></v-icon>
      </v-btn>
    </v-card-actions>
</v-card>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import NavigationBar from '@/components/NavigationBar.vue'

export default defineComponent({
    name: 'BookContainer',
    components: {
        NavigationBar,
    },
    data: () => ({
      fullName: null,
      email: null,
      password: null,
      showPassword: false,
      rules: {
        required: value => !!value || 'Required.',
        min: v => v.length >= 8 || 'Min 8 characters',
      },
      terms: false,
    }),
})
</script>