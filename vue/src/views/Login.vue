<template>
  <div>
    <div class="backgroundLogo"></div>

    <img class="logo" src="https://tinyurl.com/dinnerheart"/> 
    
    <section class="buttons">
      <div class="space"></div><div class="space"></div>
      <button class="loginShowButton" @click="toggleShowLoginForm">Login</button>
      <br>
      <login-form v-if="showLoginForm" />
      <button class="ShowButton" @click="goToRegistration">Register</button>
    </section>

  </div>
</template>

<script>
import LoginForm from "../components/LoginForm.vue";

export default {
  components: { LoginForm },
  data() {
    return {
      showLoginForm: false,
      showRegistrationForm: false,
    };
  },
  methods: {
    toggleShowLoginForm() {
      if (this.showLoginForm === true) {
        this.showLoginForm = false;
      } else this.showLoginForm = true;
    },
    goToRegistration() {
      this.$router.push("/register");
    },
  },
};
</script>

<style scoped>
@media only screen and (max-width: 600px) {
  body {
    grid-template-columns: 1fr;
    display: flex;
  }
  .space {
    margin-top: 20px;
  }
}
.space {
  margin-top: 100px;
}
.loginShowButton {
    display: block;
  margin-left: auto;
  margin-right: auto;
}
.ShowButton {
    display: block;
  margin-left: auto;
  margin-right: auto;

}
button {
    background-color: black;
  color: white;
  border-radius: 25%;
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
  padding: 10px;
  border: 2px dashed;
}
.backgroundLogo {
  /* Fill background */
  /*background-image: url("https://i1.wp.com/www.eatthis.com/wp-content/uploads/2020/12/unhealthiest-foods-planet.jpg?resize=970%2C546&ssl=1");*/
  background-color: darkred;
  min-height: 100%;
  min-width: 1024px;

  /* Scale proportionately */
  width: 100%;
  height: auto;

  /* Positioning */
  position: fixed;
  top: 0;
  left: 0;
  z-index: -1;
}
.buttons {
  display: flex;
  flex-direction: column;
  margin-top: 400px;
}
.logo {
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 50%;
}
section {
  min-height: 100vh;

  position: fixed;
  color: black;

  /* centers this div */
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);

  margin-bottom: 500px; /* determines the gap between our two sections */
}
</style>