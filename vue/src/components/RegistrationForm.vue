<template>
  <div id="register" class="body">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Create Account TEST</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <p class="password-details" v-show="displayPasswordDetails">
        Password fields must match. Password must be at least 8 characters in length and contain at least
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
    register() {    // FIX PASSWORD !MATCHING BUG  
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      }
      console.log("1" + this.registrationErrors);
      if (!this.validateEmail(this.user.email)) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Invalid Email";
      }
      console.log("2");
      if (!this.passwordMeetsCriteria()) {
        console.log("3 in passwordMeetsCriteria IF");
        this.registrationErrors = true;
        this.registrationErrorMsg =
          "Invalid Password. Password fields must match, Password Must be 8 characters minimum, including one capital letter, one lowercase, and a number";
        this.displayPasswordDetails = false;
      } 
      else if (this.registrationErrors === false) {
        console.log('4 in passwordMeetsCriteria ELSEIF')
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
      console.log('the end');
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
      

      if (hasLower && hasCapital && hasNumber && minLength ) {
        return true;
      } else return false;
    },
  },
};
</script>

<style scoped>

@media only screen and (max-width: 600px) {
  .body {
    display: flex;
    flex-wrap: wrap;
    word-wrap: normal;
  }
  .space {
    margin-top: 10px;
  }
}
.body{
  text-align: center;
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
  button {
      background-color: black;
  color: white;
  border-radius: 25%;
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
  padding: 10px;
  border: 2px dashed;
  }
  form{
  display: flex;
  flex-direction: column;
  justify-content: center, space-evenly, space-between;
  align-items: center;
  margin-top: 90px;
}
.smallSpace {
  height: 35px;
}
.hyperlink {
  color: greenyellow;
}

/* @media only screen and (min-width: 768px) {
  .body {
    display: flex;
  }
  .space {
    margin-top: 10px;
  }
}
.alert-danger {
  color: red;
} */
</style>
