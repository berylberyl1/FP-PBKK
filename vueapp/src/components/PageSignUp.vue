<template>
<NavigationBar />
<v-card class="mt-4 mx-auto pa-4" max-width="500" rounded="lg" color="white">
    <v-card-title>
        Sign up and start reading
    </v-card-title>
    <v-form validate-on="submit lazy" @submit.prevent="submit">
      <v-container class="pb-0">
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
          :error-messages="emailError"
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
          color="black"
          label="I agree to site terms and conditions"
          class="pb-0"
        ></v-checkbox>

      </v-container>

      <v-card-actions class="mt-0">
        <v-spacer></v-spacer>

        <v-btn :loading="loading" type="submit" class="px-auto text-none pa-1 px-4" variant="flat" color="primary">
          Sign up

          <v-icon icon="mdi-chevron-right" end></v-icon>
        </v-btn>

        <v-spacer></v-spacer>
      </v-card-actions>
    </v-form>
</v-card>
</template>

<script lang="js">
import { defineComponent } from 'vue';
import NavigationBar from '@/components/NavigationBar.vue'

export default defineComponent({
    name: 'PageSignUp',
    components: {
        NavigationBar,
    },
    data: () => ({
      loading: false,
      fullName: null,
      email: null,
      password: null,
      showPassword: false,
      emailError: '',
      rules: {
        required: value => !!value || 'Required.',
        min: v => v.length >= 8 || 'Min 8 characters',
      },
      terms: false,
    }),
    methods: {
      async submit () {
        this.loading = true;

        const formData = {
          fullName: this.fullName,
          email: this.email,
          password: this.password
        };

        console.log(formData);

        await fetch('api/auth/signup', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(formData),
        })
        .then(response => {
          this.loading = false;
          if (response.ok) {
            this.$router.push('/');
          } else {
            this.emailError = "Email already exist."
            throw new Error('Request failed');
          }
        })
        .then(data => {
          console.log(data);
        })
        .catch(error => {
          console.error(error);
        });
      }
    },
})
</script>