<template>
<div class="home">
<h1>LOGO</h1>
     <!-- 
    <p>You must be authenticated to see this</p>
        <p>Email: {{currentUser.email}}</p>
    <p>User Name: {{currentUser.username}}</p>
    <p>User Id: {{currentUser.userId}}</p>
    <p>Role: {{currentUser.role}}</p>  -->
<div class="space"></div><div class="space"></div><div class="space"></div>

<section class="buttons">
  <button class="select" @click="GoToRestaurantList">select restaurants</button>
    <div class="space"></div>
  <button class="select">my collection</button>
    <div class="space"></div>
  <button class="select">invite</button>
    <div class="space"></div>
  <button class="logout">logout</button>
</section>

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
@media only screen and (max-width: 600px) {
  .home {
    display: flex;
  }
  .space {
    margin-top: 10px;
  }
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
  background-color: black;
  color: white;
  border-radius: 25%;
  box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2), 0 6px 20px 0 rgba(0,0,0,0.19);
  padding: 10px;
  border: 2px dashed;
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
