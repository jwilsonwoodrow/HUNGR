<template>
  <div id="login" class="text-center">
        <img class="backgroundLogo" src="https://www.linkpicture.com/q/bg4.png"/>
    <div class="glass-container">
    <form class="form-signin" @submit.prevent="login">

        <div class="image"><img src="https://www.linkpicture.com/q/logo7_1.png" width=140px height=140px class="logo"/></div>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username or password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      ></div><br>
      <label for="email" class="sr-only">Email</label><br>
      <input
        type="text"
        id="email"
        class="form-control"
        placeholder="Email"
        v-model="user.email"
        required
        autofocus
      /><br>
      <label for="password" class="sr-only">Password</label><br>
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
  </div>
</template>

<style scoped>
    .backgroundLogo{
      min-height: 100%;
      min-width: 1024px;
      width: 100%;
      height: auto;
      position: fixed;
      top: 0;
      left: 0;
      z-index: -1;
      background-size: cover;
    }
    button {
      font-family: 'Montserrat', sans-serif;
      background: transparent;
      background-image: url("https://www.linkpicture.com/q/button-1_1.png");
      background-size: 100px 50px;
      font-weight:10;
      width: 100px;
      height: 50px;
      font-size: 100%;
      color: white;
      border: 0;
      padding: 0;
    }    button:focus {
        outline: none;
        box-shadow: none;
    }
#login {
      display: block;
    margin-left: auto;
     margin-right: auto;
     text-align: center;
}
.glass-container {
    width: 300px;
    height: 560px;
    color: white;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;

    border-radius: 10px;
    backdrop-filter: blur(5px);
    background-color: rgba(255,0,0, 0.131);
    box-shadow: rgba(0, 0, 0, 0.3) 2px 8px 8px;
    border: 4px rgba(0, 0, 0, 0.3) solid;
    border-bottom: 4px rgba(40,40,40,0.35) solid;
    border-right: 4px rgba(40,40,40,0.35) solid;
}
  .image{
    border: 3px solid rgb(252,248,200);
    border-radius: 50%;
    padding: 30px;
    background-color: rgba(124,10,2,255);
  }
  

.need {
  color: rgb(255, 234, 47);
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
            this.$router.push({name: "home"});
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
