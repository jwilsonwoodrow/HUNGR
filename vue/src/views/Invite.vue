<template>
<div>
    <!-- <date-select></date-select>
    <time-select></time-select> -->
    <restaurant-search></restaurant-search>
    <restaurant-display></restaurant-display>
</div>
</template>

<script>
// import DateSelect from '../components/DateSelect.vue'
import RestaurantDisplay from '../components/RestaurantDisplay.vue'
import RestaurantSearch from '../components/RestaurantSearch.vue' 
// import TimeSelect from '../components/TimeSelect.vue'

export default {
  name: "invite",
  components: {RestaurantSearch, RestaurantDisplay}
  }
</script>

<style scoped>
</style>