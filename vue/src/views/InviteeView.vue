<template>
  <div>
    <!-- must be inaccessable after deadline -->
    <!-- list preselected restaurants (from database?) with up/down vote options -->
    <div class="event-details">
      Event Date: {{ event.eventDate }} <br />
      RSVP Date: {{ event.expiryDate }} <br />
      <br />
      Restaurant Options: <br />
      <div
        class="restaurant-list"
        v-for="(restaurant, index) in eventDetails"
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
        <div class="popularity">
          <button
            @click="Like(restaurant.restaurantId, $route.params.id, index)"
            v-show="!voted[index]"
            class="Like"
          >
            LIKE
          </button>
          <p class="Popularity" v-show="voted[index]">
            Thanks for voting!
            Restaurant Score: {{ GetPopularity(restaurant.numOfLikes, restaurant.numOfDislikes) }}
          </p>
          <button
            @click="Dislike(restaurant.restaurantId, $route.params.id, index)"
            v-show="!voted[index]"
            class="Dislike"
          >
            DISLIKE
          </button>
        </div>
        <br />
      </div>
    </div>
    <br />
  </div>
</template>
<script>
import apiService from "../services/apiService";
export default {
  name: "invitee-view",
  data() {
    return {
      eventDetails: {},
      event: {},
      voted: [],
    };
  },
  methods: {
    Like(restaurantId, inviteId, index) {
      apiService.RestaurantVote(restaurantId, true).then((response) => {
        if (response.status === 200) {
          apiService.GetEventDetails(inviteId).then((response) => {
            this.eventDetails = response.data;
            this.voted[index] = true;
          });
        }
      });
    },
    Dislike(restaurantId, inviteId, index) {
      apiService.GetEventDetails(inviteId);
      apiService.RestaurantVote(restaurantId, false).then((response) => {
        if (response.status === 200) {
          apiService.GetEventDetails(inviteId).then((response) => {
            this.eventDetails = response.data;
            this.voted[index] = true;
          });
        }
      });
    },
    GetPopularity(likes, dislikes) {
      return likes - dislikes;
    },
  },
  created() {
    console.log(this.$route.params.id);
    //NEEDS FIXED TO DISPLAY EVENT NAME, DATE, ETC
    // apiService.GetEventById(this.$route.params.id).then((response) => {
    //   this.events = response.data;
    // });
    apiService.GetEventDetails(this.$route.params.id).then((response) => {
      this.eventDetails = response.data;
      for (let i = 0; i < this.eventDetails.length; i++) {
        this.voted[i] = false;
      }
    });
  },
};
</script>
<style>
</style>