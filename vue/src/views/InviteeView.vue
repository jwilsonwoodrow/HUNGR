<template>
  <div>
    <img class="backgroundLogo" src="https://www.linkpicture.com/q/bg4.png" />
    <button class="go-back" @click="$router.push('/invite')">
      <strong> go back </strong></button
    ><br /><br>
    <div class="glass-container">
      <!-- list preselected restaurants (from database?) with up/down vote options -->
      <div class="event-details">
        <h3>
          <div class="title">{{ event.inviteTitle }} </div><br>
          Event Time:<br> {{ formatEvent }}
          <br /><br>
          RSVP By: <br>{{ formatRSVP }} <br />
        </h3>

        <!-- <br />
        Restaurant Options: <br /> -->
        <div
          class="restaurant-list"
          v-for="(restaurant, index) in eventDetails"
          :key="restaurant.restaurantName"
        >
          <div class="name-category">
            <strong>{{ restaurant.restaurantName }}</strong
            >:
            {{ restaurant.category }}
          </div>
          <div class="address">
            {{ restaurant.restaurantStreetAddress }}<br />{{
              restaurant.restaurantCity
            }}, {{ restaurant.restaurantState }} {{ restaurant.restaurantZip
            }}<br />
          </div><br>
          <div class="popularity">
            <button
              @click="Like(restaurant.restaurantId, $route.params.id, index)"
              v-show="!voted[index]"
              class="Like"
            >
              👍</button
            ><br />
            <p class="thanks" v-show="voted[index]">
              Thanks for voting! Restaurant Score:
              {{
                GetPopularity(restaurant.numOfLikes, restaurant.numOfDislikes)
              }}
            </p>
            <button
              @click="Dislike(restaurant.restaurantId, $route.params.id, index)"
              v-show="!voted[index]"
              class="Dislike"
            >
              👎
            </button>
          </div>
          <br />
        </div>
      </div>
    </div>
    <br />
  </div>
</template>
<script>
import apiService from "../services/apiService";
export default {
  name: "invitee-view",
  computed: {
    formatRSVP() {
      console.log(this.event.expiryDate);
      let d = Date.parse(this.event.expiryDate);
      let dt = new Date(d);
      console.log(typeof dt);
      let month = dt.getMonth() +1;
      let day = dt.getDate();
      let year = dt.getFullYear();
      let time = this.event.expiryDate.slice(12, 16);
      return `${month}/${day}/${year} - ${time}`;
    },

    formatEvent() {
      console.log(this.event.eventDate);
      let d = Date.parse(this.event.eventDate);
      let dt = new Date(d);
      console.log(typeof dt);
      let month = dt.getMonth() +1;
      let day = dt.getDate();
      let year = dt.getFullYear();
      let time = this.event.eventDate.slice(12, 16);
      return `${month}/${day}/${year} - ${time}`;
    }
  },
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
    apiService.GetEventById(this.$route.params.id).then((response) => {
      this.event = response.data;
    });
    apiService.GetEventDetails(this.$route.params.id).then((response) => {
      this.eventDetails = response.data;
      for (let i = 0; i < this.eventDetails.length; i++) {
        this.voted[i] = false;
      }
    });
  },
};
</script>
<style scoped>
.thanks {
  margin-left: -70px;
}
.go-back {
  color: darkred;
  border: 3px solid darkred;
  border-radius: 25px;
  box-shadow: 2px 2px 8px 4px rgba(0,0,0,0.74);
  background: white;
  padding: 5px;
}
.title {
  font-family: 'Anton', sans-serif;
letter-spacing: 3.75px;
  background: darkred;
  border: 5px solid darkred;
  border-radius: 22px;
  margin-left: -10px;
  box-shadow: 2px 2px 8px 4px rgba(0,0,0,0.74);
  background-size: 50px 60px;
  padding-bottom: -50px;
  align-content: center;
  justify-content: center;
  width: 300px;
  height: 40px;
  font-size: 110%;
  color: rgb(253, 243, 155);

  text-shadow: -1px 3px 0 #000,
                          1px 2px 0 #000,
                         2px -1px 0 #000,
                        -1px -2px 0 #000;
}
.glass-container {
  padding-top: 20px;
  z-index: 0;
  padding-left: 30px;
  padding-right: 30px;
  padding-bottom: 30px;
  margin-right: 5px;
  text-align: center;
  overflow: auto;
  max-width: 100%;
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
.popularity {
  display: flex;
  flex-direction: row;
  justify-items: center;
  align-items: center;
  margin-left: 30%;
}
.Like {
  background-color: green;
  width: 40px;
  height: 40px;
  margin-right: 9px;
}
.Dislike {
  background-color: firebrick;
  width: 40px;
  height: 40px;
  margin-left: 9px;
}
.event-details {
  margin-top: 10px;
}
.name-category {
  color: rgb(253, 243, 155);
}
</style>