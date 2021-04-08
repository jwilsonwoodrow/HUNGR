<template>
  <div>
    <restaurant-search />
    <restaurant-display />
  </div>
</template>

<script>
import RestaurantDisplay from '../components/RestaurantDisplay.vue';
import RestaurantSearch from "../components/RestaurantSearch.vue";

export default {
  name: "view-restaurants",
  components: { RestaurantSearch, RestaurantDisplay },
};
</script>

<style>
</style>