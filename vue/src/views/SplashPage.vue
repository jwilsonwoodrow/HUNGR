<template>
  <div class="main">
    <img class="backgroundLogo" src="https://www.linkpicture.com/q/bg4.png"/>
      <div class="glass-container">
        <div class="image"><img src="https://www.linkpicture.com/q/logo7_1.png" width=140px height=140px class="logo"/></div>
        <div class="blurb"><em>Food to match your mood.</em></div>
      <button class="button loginShowButton" @click="goToLogin"><p class="logtext">Login</p></button>
      <button class="button ShowButton" @click="goToRegistration">Register</button>
    </div>
  </div>
</template>
<script>
export default {
  components: { },
  data() {
    return {
    };
  },
  methods: {
    goToLogin() {
       this.$router.push("/login");
    },
    goToRegistration() {
      this.$router.push("/register");
    },
  },
};
</script>
<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Anton&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Anton&family=Montserrat:wght@500&display=swap');
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
      font-family: 'Anton', sans-serif;
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
    }
    button:focus {
        outline: none;
        box-shadow: none;
    }
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
    .logtext {
      margin-top: 12%;
    }
.glass-container{
  margin-left: 28px;
    width: 300px;
    height: 500px;
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
  .blurb {
    color:  rgb(252,248,200);
  }
/* Portrait */
@media only screen 
  and (device-width: 320px) 
  and (device-height: 640px) 
  and (orientation: portrait) {
}
/* Landscape */
@media only screen 
  and (device-width: 320px) 
  and (device-height: 640px) 
  and (orientation: landscape) {
}
@media only screen 
   and (max-width : 800px) 
   and (max-height : 1280px) {
}
</style>