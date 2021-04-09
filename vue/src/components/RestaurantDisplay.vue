<template>
  <div id="main">
    <img class="backgroundLogo" src="https://www.linkpicture.com/q/bg4.png"/><br>
    <div
      class="restaurant-list"
      v-for="restaurant in $store.state.returnedRestaurants.businesses"
      v-bind:key="restaurant.id"
      v-show="$store.state.returnedRestaurants"
    >
      <tr>
        <th></th>
        <th></th>
      </tr>
      <tr>
        <td>
          <img
            v-bind:src="restaurant.image_url"
            alt=""
            width="150"
            height="150"
          />
        </td>
        <td class="display-text">
          {{ restaurant.name }}{{ restaurant.display_phone }}
        </td>
      </tr>
      </div>
    </div>
</template>

<script>
export default {
  name: "restaurant-display",
  components: {},
  data() {
    return {
      //restaurantList: [],
    };
  },
  created() {
    //this.restaurantList = this.$store.returnedRestaurants
  },
};
</script>

<style>
#main {
display: grid;
align-items: center;
justify-content: center;
padding-top: 30px;
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
     .display-text {
       vertical-align: middle;
        font-family: 'Montserrat', sans-serif;
        color: white;
        padding-left: 20px;
     }
@import url('https://fonts.googleapis.com/css2?family=Anton&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Anton&family=Montserrat:wght@500&display=swap');
</style>