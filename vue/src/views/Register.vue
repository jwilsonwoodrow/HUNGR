<template>
  <div id="register" class="body">
    <registration-form>  </registration-form>
  </div>
</template>

<script>
import RegistrationForm from '@/components/RegistrationForm.vue';
import authService from "../services/AuthService";

export default {
  name: "register",
  
  components: {
    RegistrationForm,
  }
  ,
};
//   methods: {
//     register() {
//       if (!this.validateEmail(this.user.email)) {
//         this.registrationErrors = true;
//         this.registrationErrorMsg = "Invalid Email";
//       }
//       if (this.user.password != this.user.confirmPassword) {
//         this.registrationErrors = true;
//         this.registrationErrorMsg = "Password & Confirm Password do not match.";
//       }
//       if (!this.passwordMeetsCriteria()) {
//         this.registrationErrors = true;
//         this.registrationErrorMsg =
//           "Invalid Password. Must be 8 characters minimum, including one capital letter, one lowercase, and a number";
//         this.displayPasswordDetails = false;
//       } else {
//         authService
//           .register(this.user)
//           .then((response) => {
//             if (response.status == 201) {
//               this.$router.push({
//                 path: "/login",
//                 query: { registration: "success" },
//               });
//             }
//           })
//           .catch((error) => {
//             const response = error.response;
//             this.registrationErrors = true;
//             if (response.status === 400) {
//               this.registrationErrorMsg = "Bad Request: Validation Errors";
//             }
//             if (response.status === 409) {
//               this.registrationErrorMsg =
//                 "The email address or username is already in use";
//             }
//           });
//       }
//     },
//     clearErrors() {
//       this.registrationErrors = false;
//       this.registrationErrorMsg = "There were problems registering this user.";
//     },
//     validateEmail(mail) {
//       if (
//         /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/.test(
//           mail
//         )
//       ) {
//         return true;
//       }
//       this.registrationErrors = false;
//       this.registrationErrorMsg = "You have entered an invalid email address!";
//       return false;
//     },

//     passwordMeetsCriteria() {
//       let hasLower = false;
//       let hasCapital = false;
//       let hasNumber = false;
//       let minLength = false;
//       let lowerLetters = /[a-z]/g;
//       let capitalLetters = /[A-Z]/g;
//       let numbers = /[0-9]/g;

//       if (this.user.password.match(lowerLetters)) {
//         hasLower = true;
//       }
//       if (this.user.password.match(capitalLetters)) {
//         hasCapital = true;
//       }
//       if (this.user.password.match(numbers)) {
//         hasNumber = true;
//       }
//       if (this.user.password.length > 7) {
//         minLength = true;
//       }

//       if (hasLower && hasCapital && hasNumber && minLength) {
//         return true;
//       } else return false;
//     },
//   },
// };
</script>

<style scoped>
.alert-danger {
  color: red;
}
</style>
