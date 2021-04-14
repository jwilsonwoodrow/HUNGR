<template>
  <div>
    <!-- display list of all events with current user's id -->
    <!-- clicking on list of object will go to invite details -->
    <div
      class="event-list"
      v-for="(event, index) in events"
      :key="event.inviteId"
    >
      <button @click="GetDetails(event.inviteId, index)">
        {{ event.inviteTitle }}
      </button>
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
  },
  updated() {
    for (let i = 0; i < this.events.length; i++) {
      this.displayDetails[i] = false;
    }
  },
};
</script>

<style>
</style>