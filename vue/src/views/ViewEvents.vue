<template>
  <div id="main">
    <p>My Events</p>
     <img
      class="backgroundLogo"
      src="https://www.linkpicture.com/q/bg4.png"
    />
    <!-- display list of all events with current user's id -->
    <!-- clicking on list of object will go to invite details -->
    <div class="glass-container">
    <div
      class="event-list"
      v-for="(event, index) in events"
      :key="event.inviteId"
    >
      <button @click="GetDetails(event.inviteId, index)" class="btn">
        {{ event.inviteTitle }}
      </button><br>
      <div class="event-details" v-show="displayDetails[index]">
        Event Date: {{ event.eventDate }} <br />
        RSVP Date: {{ event.expiryDate }} <br />
        <br />
        Restaurant Options: <br />
        <div
          class="restaurant-list"
          v-for="restaurant in eventDetails"
          :key="restaurant.restaurantName"
        >
          <div class="name-category">
            <strong>{{ restaurant.restaurantName }}</strong> -
            {{ restaurant.category }}
          </div>
          <div class="address">
            {{ restaurant.restaurantStreetAddress }}<br />{{
              restaurant.restaurantCity
            }}, {{ restaurant.restaurantState }} {{ restaurant.restaurantZip
            }}<br />
          </div>
          <!-- call now icon -->
          <a
            v-bind:href="'tel:' + restaurant.phoneNumber"
            v-show="!restaurant.is_closed"
            class="call"
          ></a>
          <br />
        </div>
      </div>
          <div class="popularity">
            <button @click="Like(restaurant.restaurantId)" v-show="!voted">
              LIKE
            </button>
            <button @click="Dislike(restaurant.restaurantId)" v-show="!voted">
              DISLIKE
            </button>
          </div>
          <!-- call now icon -->
          <a v-bind:href="'tel:' + restaurant.phoneNumber" class="call"></a>
          <br />
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import apiService from "../services/apiService";
export default {
  name: "events",
  data() {
    return {
      events: [],
      displayDetails: [],
      eventDetails: [],
      voted: false,
    };
  },
  created() {
    apiService.GetEvents().then((response) => {
      this.events = response.data;
    });
  },
  methods: {
    GetDetails(inviteId, index) {
      apiService.GetEventDetails(inviteId).then((response) => {
        this.eventDetails = response.data;
        if (this.displayDetails[index] === true) {
          this.displayDetails[index] = false;
        } else {
          this.displayDetails.fill(false);
          this.displayDetails[index] = true;
        }
      });
    },
    Like(restaurantId) {
      console.log(restaurantId)
      apiService.RestaurantVote(restaurantId, true).then((response) => {
        if (response.status === 200) {
          console.log("yes");
        }
      });
    },
    Dislike(restaurantId) {
      apiService.RestaurantVote(restaurantId, false).then((response) => {
        if (response.status === 200) {
          console.log("yes");
        }
      });
    },
  },
  updated() {
    for (let i = 0; i < this.events.length; i++) {
      this.displayDetails[i] = false;
    }
  },
};
</script>
<style scoped>
.btn {
    font-family: "Montserrat", sans-serif;
  background: transparent;
  background-image: url("https://www.linkpicture.com/q/button-1_1.png");
  background-size: 50px 60px;
  font-weight: 10;
  width: 100px;
  height: 60px;
  font-size: 85%;
  color: rgb(253, 243, 155);
  border: 0;
  padding: 0;
}
p {
  font-family: "Montserrat", sans-serif;
  color: rgb(253, 243, 155);
  background-color: darkred;
  text-align: center;
}
.glass-container {
  padding-top: 20px;
  padding-left: 30px;
  padding-right: 30px;
  padding-bottom: 30px;
  margin-right: 5px;
  text-align: center;
  overflow: auto;
  max-width: 100%; /* or can do fit-content here?? */
  height: fit-content;
  color: white;
  display: flex;
  position: relative;
  flex-direction: column;
  justify-content: space-evenly;
  align-items: left;
  gap: 20px;
  border-radius: 10px;
  backdrop-filter: blur(5px);
  background-color: rgba(255, 0, 0, 0.131);
  box-shadow: rgba(0, 0, 0, 0.3) 2px 8px 8px;
  border: 4px rgba(0, 0, 0, 0.3) solid;
  border-bottom: 4px rgba(40, 40, 40, 0.35) solid;
  border-right: 4px rgba(40, 40, 40, 0.35) solid;
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