<template>
  <div id="main">
    <button class="go-back" @click="$router.push('/home')">
      <strong> go back </strong></button
    ><br />
    <p>MY EVENTS</p>
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
      <button class="btn" @click="GetDetails(event.inviteId, index)">
        <strong>{{ event.inviteTitle.toUpperCase() }}</strong></button
      ><br />
      <div class="event-details" v-show="displayDetails[index]">
        Event Date: {{ formatEvent(event) }} <br />
        RSVP Date: {{ formatRSVP(event) }} <br />
        <h2>shareable link</h2>
        <input type="text" name="event-link" id="event-link" v-bind:value='`http://localhost:8080/invite/${event.inviteId}`' readonly>
        <br /><br>
        <!-- <em class="options">Restaurant Options</em> <br /> -->
        <div
          class="restaurant-list"
          v-for="restaurant in eventDetails"
          :key="restaurant.restaurantName"
        >
          <div class="name-category">
            <strong>{{ restaurant.restaurantName }}</strong>:
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
              @click="Like(restaurant.restaurantId, event.inviteId, index)"
              v-show="!voted"
              class="Like"
            >
              👍
            </button>
            <h4 class="Popularity">
              {{
                GetPopularity(restaurant.numOfLikes, restaurant.numOfDislikes)
              }}
            </h4>
            <button
              @click="Dislike(restaurant.restaurantId, event.inviteId, index)"
              v-show="!voted"
              class="Dislike"
            >
              👎
            </button>
          </div>
          <br />
        </div>
      </div>
      <br />
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
      if (this.displayDetails[index] === true) {
        this.displayDetails[index] = false;
      } else {     
        this.displayDetails.fill(false);
        apiService.GetEventDetails(inviteId).then((response) => {
          this.eventDetails = response.data;

          this.displayDetails[index] = true;
        });
      }
    },
    Like(restaurantId, inviteId, index) {
      apiService.RestaurantVote(restaurantId, true).then((response) => {
        if (response.status === 200) {
          apiService.GetEventDetails(inviteId).then((response) => {
            this.eventDetails = response.data;
            this.displayDetails[index] = true; //only the finest spaghetti
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
            this.displayDetails[index] = true; //only the finest spaghetti
          });
        }
      });
    },
    GetPopularity(likes, dislikes, inviteId, index) {
      return likes - dislikes;
    },
    formatRSVP(event) {
      console.log(event);
      let d = Date.parse(event.expiryDate);
      let dt = new Date(d);
      let month = dt.getMonth() +1;
      let day = dt.getDate();
      let year = dt.getFullYear();
      let time = event.expiryDate.slice(12, 16);
      return `${month}/${day}/${year} - ${time}`;
    },
    formatEvent(event) {
      let d = Date.parse(event.eventDate);
      let dt = new Date(d);
      let month = dt.getMonth() +1;
      let day = dt.getDate();
      let year = dt.getFullYear();
      let time = event.eventDate.slice(12, 16);
      return `${month}/${day}/${year} - ${time}`;
    }
  },
  updated() {
    for (let i = 0; i < this.events.length; i++) {
      this.displayDetails[i] = false;
    }
  },
  
}
</script>
<style scoped>
@import url('https://fonts.googleapis.com/css2?family=Rye&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Rammetto+One&display=swap');
@import url('https://fonts.googleapis.com/css2?family=Anton&display=swap');
.go-back {
  color: darkred;
  border: 3px solid darkred;
  border-radius: 25px;
  box-shadow: 2px 2px 8px 4px rgba(0,0,0,0.74);
  background: white;
  padding: 5px;
}
.btn {
font-family: 'Anton', sans-serif;
letter-spacing: 3.75px;
  background: darkred;
  border: 5px solid darkred;
  border-radius: 22px;
  box-shadow: 2px 2px 8px 4px rgba(0,0,0,0.74);
  background-size: 50px 60px;
  width: 300px;
  height: 60px;
  font-size: 110%;
  color: rgb(253, 243, 155);
  border: 0;
  text-shadow: -1px 3px 0 #000,
                          1px 2px 0 #000,
                         2px -1px 0 #000,
                        -1px -2px 0 #000;
  /* padding-left: 30px;
  padding-right: 30px; */
}
p {
font-family: 'Rammetto One', cursive;
text-shadow: -1px 1px 0 #000,
                          1px 1px 0 #000,
                         1px -1px 0 #000,
                        -1px -1px 0 #000;
  color: white;
  padding: 5px;
  font-size: 48px;
  text-align: center;

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
.event-list {
  margin-bottom: -20px;
}

</style>