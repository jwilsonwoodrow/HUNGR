<template>
  <div>
    <div class="backgroundLogo"></div>
    <section>
      <button class="loginShowButton" @click="toggleShowLoginForm">
        Login
      </button>
      <login-form v-if="showLoginForm" />
      <button class="ShowButton" @click="goToRegistration">Register</button>
    </section>
  </div>
</template>

<script>
import LoginForm from "../components/LoginForm.vue";
import RegistrationForm from "../components/RegistrationForm.vue";

export default {
  components: { LoginForm, RegistrationForm },
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
.backgroundLogo {
  /* Fill background */
  background-image: url("https://i1.wp.com/www.eatthis.com/wp-content/uploads/2020/12/unhealthiest-foods-planet.jpg?resize=970%2C546&ssl=1");
  min-height: 100%;
  min-width: 1024px;

  /* Scale proportionately */
  width: 100%;
  height: auto;

  /* Positioning */
  position: fixed;
  top: 0;
  left: 0;
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