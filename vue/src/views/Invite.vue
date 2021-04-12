<template>
<div>
  <button class="select" @click="$router.push('/home')"><strong> go back </strong></button><br>
    <event-title-select></event-title-select>
    <date-select></date-select>
    <collection-display></collection-display>
    <br>
    <!-- This button will compile selections into a list, that can then be sent as an invite. Routes to "Invite-Confirmation"-->
    <button class="select" @click="$router.push('/inviteconfirmation')"><strong> complete </strong></button><br> 
</div>
</template>

<script>
import CollectionDisplay from '../components/CollectionDisplay.vue'
import DateSelect from '../components/DateSelect.vue'
import EventTitleSelect from '../components/EventTitleSelect.vue'

export default {
  name: "invite",
  components: {DateSelect, CollectionDisplay, EventTitleSelect}
  }
</script>

<style scope,
    CollectionDisplayd>
</style>