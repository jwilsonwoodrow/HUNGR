<template>
  <div class="main">
    <login-form></login-form>
  </div>
</template>
<script>
import LoginForm from "../components/LoginForm.vue";
export default {
  components: { LoginForm },
  data() {
    return {};
  },
};
</script>
<style scoped>
@import url("https://fonts.googleapis.com/css2?family=Anton&display=swap");
@import url("https://fonts.googleapis.com/css2?family=Anton&family=Montserrat:wght@500&display=swap");
/* ----------- Galaxy S3 ----------- */
/* Portrait and Landscape */
/* @media only screen
  and (device-width: 360px) 
  and (device-height: 640px) { */
.main {
  display: flex;
  height: 100vh;
  width: 100vw;
  flex-direction: column;
  justify-content: center;
  align-content: center;
  font-family: "Anton", sans-serif;
}
button {
  font-family: "Montserrat", sans-serif;
  font-weight: 10;
  background-image: url("https://i.ibb.co/0K6R2px/button.png");
  width: 100px;
  height: 50px;
  font-size: 100%;
  color: white;
}
.backgroundLogo {
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
.glass-container {
  width: 60%;
  height: 75%;
  padding: 30px;
  color: white;
  justify-content: center;
  align-items: center;
  border-radius: 10px;
  backdrop-filter: blur(5px);
  background-color: rgba(255, 0, 0, 0.131);
  box-shadow: rgba(0, 0, 0, 0.3) 2px 8px 8px;
  border: 4px rgba(0, 0, 0, 0.3) solid;
  border-bottom: 4px rgba(40, 40, 40, 0.35) solid;
  border-right: 4px rgba(40, 40, 40, 0.35) solid;
}
.logo {
  border: 3px solid rgb(252, 248, 200);
  border-radius: 50%;
  padding: 30px;
  background-color: rgba(124, 10, 2, 255);
}
.blurb {
  color: rgb(252, 248, 200);
}
/* Portrait */
@media only screen and (device-width: 320px) and (device-height: 640px) and (orientation: portrait) {
}
/* Landscape */
@media only screen and (device-width: 320px) and (device-height: 640px) and (orientation: landscape) {
}
@media only screen and (max-width: 800px) and (max-height: 1280px) {
}
</style>