<template>
  <div>
    <div
      class="restaurant-list"
      v-for="restaurant in $store.state.returnedRestaurants"
      v-bind:key="restaurant.id"
      v-show="$store.state.returnedRestaurants"
    >
    <img v-bind:src = restaurant.image_url alt="" width="250" height="250" />
    <p> {{ restaurant.name }}{{ restaurant.display_phone }}</p>
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
</style>