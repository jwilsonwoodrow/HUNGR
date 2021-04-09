<template>
  <div>
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
            width="250"
            height="250"
          />
        </td>
        <td>
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
</style>