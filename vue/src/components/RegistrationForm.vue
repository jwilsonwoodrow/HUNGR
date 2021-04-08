<template>
  <div id="register" class="body">
    <img class="backgroundLogo" src="https://www.linkpicture.com/q/bg4.png"/>
    <div class="glass-container">
    <form class="form-register" @submit.prevent="register">
       <div class="image"><img src="https://www.linkpicture.com/q/logo7_1.png" width=140px height=140px class="logo"/></div>
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <!--<p class="password-details" v-show="displayPasswordDetails">
        Password fields must match. Password must be at least 8 characters in length and contain at least
        one uppercase letter, one lowercase letter, and one number.
      </p>* -->
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
      <router-link class="hyperlink need" :to="{ name: 'login' }"><p class="need">Have an account?</p></router-link>
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        Create Account
      </button>
    </form>
    </div>
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
@import url('https://fonts.googleapis.com/css2?family=Anton&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Anton&family=Montserrat:wght@500&display=swap');
/* @media only screen and (max-width: 600px) { */
 .body {
display: flex;
    height: 100vh;
    width: 100vw;
    flex-direction: column;
    justify-content: center;
    align-content: center;
    font-family: 'Anton', sans-serif;
}
  .space {
    margin-top: 10px;
  }
    button {
      font-family: 'Montserrat', sans-serif;
      background: transparent;
      background-image: url("https://www.linkpicture.com/q/button-1_1.png");
      background-size: 100px 50px;
      font-weight:10;
      width: 100px;
      height: 50px;
      font-size: 70%;
      color: white;
      border: 0;
      padding: 0;
    }    button:focus {
        outline: none;
        box-shadow: none;
    }
  form{
  display: flex;
  flex-direction: column;
  justify-content: center, space-evenly, space-between;
  align-items: center;
}
.need {
  color: rgb(255, 234, 47);
}
.smallSpace {
  height: 35px;
}
.hyperlink {
  color:  rgb(255, 234, 47);
}
.glass-container{
  margin-left: 28px;
    width: 300px;
    height: 700px;
    color: white;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    gap: 20px;
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
    .backgroundLogo{
      min-height: 100%;
      min-width: 1024px;
      width: 100%;
      height: auto;
      position: fixed;
      top: 0;
      left: 0;
      background-size: cover;
    }

/* @media only screen and (min-width: 768px) {
  .body {
    display: flex;
  }
  .space {
    margin-top: 10px;
  }
}*/
.alert-danger {
  color: red;
} 
</style>
