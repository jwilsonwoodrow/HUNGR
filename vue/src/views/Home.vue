<template>
<div class="home">
  <img class="backgroundLogo" src="https://www.linkpicture.com/q/bg4.png"/>
    <div class="glass-container">
        <div class="image"><img src="https://www.linkpicture.com/q/logo2_9.png" width=140px height=140px class="logo"/></div>
<section class="buttons">
  <button class="select" @click="GoToRestaurantList">select restaurants</button><br>
  <button class="select" >my collection</button><br>
  <button class="select">invite</button><br>
  <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''"><button class="logout">Logout</button></router-link>
</section>
</div>
</div>
</template>

<script>
export default {
  name: "home",
  computed: {
    currentUser() {
      return this.$store.state.user;
    },
  },
  methods: {
    GoToRestaurantList(){
      this.$router.push('/restaurants')
    }
  }
};
</script>

<style scoped>
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
  .space {
    margin-top: 10px;
  }
.home {
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
.buttons {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.select{
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
      .image{
    border: 3px solid rgb(252,248,200);
    border-radius: 50%;
    padding: 30px;
    background-color: rgba(124,10,2,255);
  }
.logout {
 background-color: white;
 border-color: darkred;
 color: darkred;
 font-size: 16px;
 font-weight: bold;
 border-radius: 12%;
 box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
 padding: 10px;
}
.space {
  margin-top: 100px;
}
</style>
