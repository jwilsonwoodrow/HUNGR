<template>
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username or password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      ></div>
      <label for="email" class="sr-only">Email: </label><br>
      <input
        type="text"
        id="email"
        class="form-control"
        placeholder="Email"
        v-model="user.email"
        required
        autofocus
      /><br>
      <label for="password" class="sr-only">Password: </label><br>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      /><br><br>
      <button type="submit">Sign in</button><br><br>
      <router-link :to="{ name: 'register' }" class="need">Need an account?</router-link><br><br>

    </form>
  </div>
</template>

<style scoped>
button {
    background-color: black;
  color: white;
  border-radius: 25%;
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
  padding: 10px;
  border: 2px dashed;
}
#login {
    display: block;
  margin-left: auto;
  margin-right: auto;
  text-align: center;
}
.need {
  color: greenyellow;
}
</style>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        email: "",
        // username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>
