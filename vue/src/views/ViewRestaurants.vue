<template>
  <div>
    <button class="go-back" @click="$router.push('/home')">
      <strong> go back </strong></button
    ><br />
    <restaurant-search />
    <restaurant-display />
  </div>
</template>

<script>
import RestaurantDisplay from "../components/RestaurantDisplay.vue";
import RestaurantSearch from "../components/RestaurantSearch.vue";

export default {
  name: "view-restaurants",
  components: { RestaurantSearch, RestaurantDisplay },
};
</script>

<style>
.go-back {
  color: darkred;
  border: 3px solid darkred;
  border-radius: 25px;
  box-shadow: 2px 2px 8px 4px rgba(0,0,0,0.74);
  background: white;
  padding: 5px;
}
</style>