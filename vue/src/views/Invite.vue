<template>
<div>
  <button class="select" @click="$router.push('/home')"><strong> go back </strong></button><br>
    <date-select></date-select>
    <time-select></time-select>
    <restaurant-search></restaurant-search>
    <restaurant-display></restaurant-display>
    <!-- This button will compile selections into a list, that can then be sent as an invite. Routes to "Invite-Confirmation"-->
    <button class="select" @click="$router.push('/inviteconfirmation')"><strong> complete </strong></button><br> 
</div>
</template>

<script>
import DateSelect from '../components/DateSelect.vue'
import RestaurantDisplay from '../components/RestaurantDisplay.vue'
import RestaurantSearch from '../components/RestaurantSearch.vue' 
import TimeSelect from '../components/TimeSelect.vue'

export default {
  name: "invite",
  components: {RestaurantSearch, RestaurantDisplay, DateSelect, TimeSelect}
  }
</script>

<style scoped>
</style>