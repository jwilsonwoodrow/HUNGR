<template>
  <div id="register" class="text-center">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <p class="password-details" v-show="displayPasswordDetails">
        Password must be at least 8 characters in length and contain at least
        one uppercase letter, one lowercase letter, and one number.
      </p>
      <label for="email" class="sr-only">Email</label>
      <input
        type="text"
        id="email"
        class="form-control"
        placeholder="Email"
        v-model="user.email"
        required
        autofocus
      />
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <input
        type="password"
        id="confirmPassword"
        class="form-control"
        placeholder="Confirm Password"
        v-model="user.confirmPassword"
        required
      />
      <router-link :to="{ name: 'login' }">Have an account?</router-link>
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        Create Account
      </button>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "register",
  data() {
    return {
      user: {
        email: "",
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
      displayPasswordDetails: true,
    };
  },
  methods: {
    register() {
      if (!this.validateEmail(this.user.email)) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Invalid Email";
      }
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      }
      if (!this.passwordMeetsCriteria()) {
        this.registrationErrors = true;
        this.registrationErrorMsg =
          "Invalid Password. Must be 8 characters minimum, including one capital letter, one lowercase, and a number";
        this.displayPasswordDetails = false;
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
            if (response.status === 409) {
              this.registrationErrorMsg =
                "The email address or username is already in use";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
    validateEmail(mail) {
      if (
        /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(
          mail
        )
      ) {
        return true;
      }
      this.registrationErrors = false;
      this.registrationErrorMsg = "You have entered an invalid email address!";
      return false;
    },

    passwordMeetsCriteria() {
      let hasLower = false;
      let hasCapital = false;
      let hasNumber = false;
      let minLength = false;
      let lowerLetters = /[a-z]/g;
      let capitalLetters = /[A-Z]/g;
      let numbers = /[0-9]/g;

      if (this.user.password.match(lowerLetters)) {
        hasLower = true;
      }
      if (this.user.password.match(capitalLetters)) {
        hasCapital = true;
      }
      if (this.user.password.match(numbers)) {
        hasNumber = true;
      }
      if (this.user.password.length > 7) {
        minLength = true;
      }

      if (hasLower && hasCapital && hasNumber && minLength) {
        return true;
      } else return false;
    },
  },
};
</script>

<style scoped>
.alert-danger {
  color: red;
}
</style>
