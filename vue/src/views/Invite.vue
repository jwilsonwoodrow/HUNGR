<template>
  <div>
    <button class="select" @click="$router.push('/home')">
      <strong> go back </strong>
    </button>
    <div>
      <label for="eventName"> What is the name of your Event? </label>
      <input
        v-model="invite.inviteTitle"
        id="eventName"
        type="text"
        name="eventName"
      />
    </div>
    <div>
      <label for="eventDateTime"> What day do you want to meet? </label>
      <input
        v-model="invite.eventDate"
        id="eventDateTime"
        type="datetime-local"
        name="eventDate"
      />
    </div>
    <div>
      <label for="rsvpDateTime"> RSVP by? </label>
      <input
        v-model="invite.expiryDate"
        id="rsvpDateTime"
        type="datetime-local"
        name="rsvpDate"
      />
    </div>
    <!-- This button will compile selections into a list, that can then be sent as an invite. Routes to "Invite-Confirmation"-->
    <button class="select" @click.prevent="SaveEvent">
      <strong> complete </strong></button
    ><br />
  </div>
</template>

<script>
import apiService from "../services/apiService";
// import CollectionDisplay from "../components/CollectionDisplay.vue";

export default {
  name: "invite",
  data() {
    return {
      invite: {},
    };
  },
  // components: { DateSelect, CollectionDisplay, EventTitleSelect },
  methods: {
    SaveEvent() {
      apiService.CreateEvent(this.invite).then((response) => {
        if(response.status >= 200 && response.status < 300){
          console
          let inviteID = response.data.inviteId;
          apiService.CreateRestaurants(this.$store.state.savedRestaurants).then((response) =>{
            if(response.status === 200){
              let restaurantIDs = response.data
              apiService.RelateEventRestaurant(inviteID, restaurantIDs).then((response) => {
                if(response.status === 200){
                  this.$store.commit("CLEAR_SAVED_RESTAURANTS")
                }
              })
            }
          });
        }
      });
    },
  },
};
</script>

<style scoped,
    CollectionDisplay>
</style>