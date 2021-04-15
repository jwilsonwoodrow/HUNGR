<template>
  <div>
    <img
      class="backgroundLogo"
      src="https://www.linkpicture.com/q/bg4.png"
    /><br />
    <button class="back" @click="$router.push('/collection')">
      <strong> go back </strong>
    </button>
    <div class="glass-container">
      <div class="body">
        <label for="eventName"> Your Event Name </label>
        <input
          v-model="invite.inviteTitle"
          id="eventName"
          type="text"
          name="eventName"
        />
      </div>
      <div>
        <label for="eventDateTime"> Event Time and Date </label>
        <br>
        <input
          v-model="invite.eventDate"
          id="eventDateTime"
          type="datetime-local"
          name="eventDate"
        />
      </div>
      <div>
        <label for="rsvpDateTime"> RSVP Deadline </label><br />
        <input
          v-model="invite.expiryDate"
          id="rsvpDateTime"
          type="datetime-local"
          name="rsvpDate"
        />
      </div>
      <!-- This button will compile selections into a list, that can then be sent as an invite. Routes to "Invite-Confirmation"-->
      <button class="select" @click.prevent="SaveEvent">
        <strong> Complete </strong></button
      ><br />
    </div>
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
        if (response.status >= 200 && response.status < 300) {
          let inviteID = response.data.inviteId;
          apiService
            .CreateRestaurants(this.$store.state.savedRestaurants)
            .then((response) => {
              if (response.status === 200) {
                let restaurantIDs = response.data;
                apiService
                  .RelateRestaurantLikes(restaurantIDs)
                  .then((response) => {
                    if (response.status === 200) {
                      apiService
                        .RelateEventRestaurant(inviteID, restaurantIDs)
                        .then((response) => {
                          if (response.status === 200) {
                            this.$store.commit("CLEAR_SAVED_RESTAURANTS")
                            this.$router.push({ name: "events" });
                          }
                        });
                    }
                  });
              }
            });
        }
      });
    },
  },
};
</script>

<style scoped>
.body {
  display: flex;
  flex-direction: column;
  align-items: center;
}
.backgroundLogo {
  min-height: 100%;
  min-width: 400px;
  width: 100%;
  height: auto;
  position: fixed;
  top: 0;
  left: 0;
  z-index: -1;
  background-size: cover;
}
.glass-container {
  padding-top: 15px;
  margin-top: 15px;
  margin-left: 5px;
  text-align: center;
  overflow: auto;
  max-width: 90%; /* or can do fit-content here?? */
  height: fit-content;
  color: white;
  display: flex;
  position: relative;
  flex-direction: column;
  justify-content: space-evenly;
  align-items: center;
  gap: 20px;
  border-radius: 10px;
  backdrop-filter: blur(5px);
  background-color: rgba(255, 0, 0, 0.131);
  box-shadow: rgba(0, 0, 0, 0.3) 2px 8px 8px;
  border: 4px rgba(0, 0, 0, 0.3) solid;
  border-bottom: 4px rgba(40, 40, 40, 0.35) solid;
  border-right: 4px rgba(40, 40, 40, 0.35) solid;
}
.select {
  font-family: "Montserrat", sans-serif;
  background: transparent;
  background-image: url("https://www.linkpicture.com/q/button-1_1.png");
  background-size: 100px 60px;
  font-weight: 10;
  width: 100px;
  height: 60px;
  font-size: 93%;
  color: rgb(253, 243, 155);
  border: 0;
  padding: 0;
}
</style>