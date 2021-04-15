<template>
  <div>
    <img class="backgroundLogo" src="https://www.linkpicture.com/q/bg4.png" />
    <div id="home">
      <div class="glass-container">
        <section class="buttons">
          <div class="image">
            <img
              src="https://www.linkpicture.com/q/logo5_2.png"
              width="auto"
              height="145px"
              class="logo"
            />
          </div>
          <br />
          <button class="select" @click="GoToRestaurantList">
            <strong> RESTAURANTS </strong></button
          ><br />
          <button class="select" @click="$router.push('/collection')">
            <strong> CREATE EVENT </strong></button
          ><br />
          <button class="select" @click="$router.push('/events')">
            <strong> MY EVENTS </strong></button
          ><br />
          <router-link
            v-bind:to="{ name: 'logout' }"
            v-if="$store.state.token != ''"
            ><button class="logout">Logout</button></router-link
          >
        </section>
      </div>
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
    GoToRestaurantList() {
      this.$router.push("/restaurants");
    },
  },
  GoToInviteList() {
    this.$router.push("/invite");
  },
  GoToCollectionList() {
    this.$router.push("/collection");
  },
};
</script>
<style scoped>
#home {
  position: absolute;
  top: 50%;
  left: 50%;
  margin: -300px 0 0 -150px;
  font-family: "Anton", sans-serif;
}
.glass-container {
  min-width: 300px;
  height: 610px;
  color: white;
  display: flex;
  /* flex-direction: column; */
  justify-content: center;
  align-items: center;
  gap: 20px;
  border-radius: 10px;
  backdrop-filter: blur(5px);
  background-color: rgba(255, 0, 0, 0.131);
  box-shadow: rgba(0, 0, 0, 0.3) 2px 8px 8px;
  border: 4px rgba(0, 0, 0, 0.3) solid;
  border-bottom: 4px rgba(40, 40, 40, 0.35) solid;
  border-right: 4px rgba(40, 40, 40, 0.35) solid;
}
.buttons {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}
.select {
  font-family: "Montserrat", sans-serif;
  background: transparent;
  background-image: url("https://www.linkpicture.com/q/button-1_1.png");
  background-size: 140px 50px;
  font-weight: 10;
  width: 140px;
  height: 50px;
  font-size: 80%;
  color: rgb(253, 243, 155);
  border: 0;
  padding: 0;
}
button:focus {
  outline: none;
  box-shadow: none;
}
.backgroundLogo {
  min-height: 100%;
  width: 100%;
  height: auto;
  position: fixed;
  top: 0;
  left: 0;
  z-index: -1;
  background-size: cover;
}
.image {
  border: 3px solid rgb(252, 248, 200);
  border-radius: 50%;
  padding: 30px;
  background-color: rgba(124, 10, 2, 255);
}
.logout {
  background-color: white;
  border-color: darkred;
  color: darkred;
  font-size: 12px;
  font-weight: bolder;
  border-radius: 12%;
  box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
  padding: 7px;
}
</style>