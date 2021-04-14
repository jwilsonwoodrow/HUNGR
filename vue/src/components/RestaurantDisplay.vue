<template>
  <div id="main">
    <img
      class="backgroundLogo"
      src="https://www.linkpicture.com/q/bg4.png"
    /><br />

    <!--  -->
    <div class="glass-container">
      <div v-if="$store.state.returnedRestaurants.businesses">
        <div
          class="restaurant-list"
          v-for="(restaurant, index) in $store.state.returnedRestaurants
            .businesses"
          v-bind:key="restaurant.id"
          v-show="$store.state.returnedRestaurants"
        >
          <img
            v-bind:src="restaurant.image_url"
            alt="No Image Available"
            width="200"
            height="190"
            class="img"
          />
          <div class="name-category">
            <strong>{{ restaurant.name }}</strong> -
            {{ restaurant.categories[0].title }}
          </div>
          <br />
          <div class="address">
            {{ restaurant.location.address1 }}<br />{{
              restaurant.location.city
            }}, {{ restaurant.location.state }} {{ restaurant.location.zip_code
            }}<br />
          </div>
          <div class="is-closed" v-show="!restaurant.is_closed">Open Now</div>
          <div class="is-closed" v-show="restaurant.is_closed">Closed</div><br>
          <!-- call now icon -->
          <a
            v-bind:href="'tel:' + restaurant.phone"
            v-show="!restaurant.is_closed"
            class="call"
          >
          Call Now</a
          ><br /><br>
          <button
            class="save-restaurant-button"
            @click="SaveRestaurant(restaurant)"
            v-show="!ExistsInCollection(restaurant)"
          >
            SAVE TO EVENT LIST
          </button>
          <button
            class="save-restaurant-button"
            @click="UnsaveRestaurant(restaurant)"
            v-show="ExistsInCollection(restaurant)"
          >
            REMOVE FROM EVENT LIST
          </button>
          <br />
          <br />
        </div>
      </div>
      <div
        class="no-returned-restaurants"
        v-if="$store.state.returnedRestaurants.businesses.length === 0"
      >
        No Results In Your Area :(
      </div>
    </div>
  </div>
</template>

<script>
import apiService from "../services/apiService";
export default {
  name: "restaurant-display",
  components: {},
  data() {
    return {
      displayDetails: [], //array of booleans, one for each displayed restaurant so that they can be toggled individually
    };
  },
  computed: {},
  methods: {
    getRestaurantDetails: function (restaurantId, index) {
      if (this.displayDetails[index] === true) {
        this.displayDetails[index] = false;
      } else this.displayDetails[index] = true;
      apiService.getBusinessByID(restaurantId).then((response) => {
        console.log(response.data);
      });
    },
    SaveRestaurant: function (restaurant) {
      console.log(restaurant);
      this.$store.commit("SAVE_RESTAURANT", restaurant);
    },
    UnsaveRestaurant(restaurant) {
      this.$store.commit("UNSAVE_RESTAURANT", restaurant);
    },
    ExistsInCollection: function (restaurant) {
      if (this.$store.state.savedRestaurants.includes(restaurant)) {
        return true;
      } else {
        return false;
      }
    },
  },
  updated() {
    console.log(this.$store.state.returnedRestaurants.businesses.length);
    for (
      let i = 0;
      i < this.$store.state.returnedRestaurants.businesses.length;
      i++
    ) {
      this.displayDetails[i] = false;
    }
  },
};
</script>

<style scoped>
a {
  background-color: rgb(253, 243, 155);
  color: darkred;
  padding: 0.2em 1em;
  text-decoration: none;
  text-transform: uppercase;
  box-shadow: 0px 0px 7px 7px rgba(253, 243, 155, 0.42);
  font-family: "Montserrat", sans-serif;
}
button:focus {
  outline: 3;
  box-shadow: none;
}
input {
  font-family: "Montserrat", sans-serif;
  background-color: rgb(253, 243, 155);
}
select {
  background-color: rgb(253, 243, 155);
  font-family: "Montserrat", sans-serif;
}
.details-button,
.save-restaurant-button {
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
button:focus {
  outline: none;
  box-shadow: none;
}
#main {
  display: grid;
  align-items: center;
  justify-content: center;
  padding-top: 30px;
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
  margin-right: 5px;
  text-align: center;
  overflow: auto;
  max-width: 100%; /* or can do fit-content here?? */
  height: fit-content;
  color: white;
  display: flex;
  position: absolute;
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
.restaurant-list {
  z-index: 0;
}
.img {
  margin-left: 8px;
  box-shadow: 0px 0px 7px 7px rgba(253, 243, 155, 0.42);
  border: 2px solid rgba(253, 243, 155, 0.42);
}
@import url("https://fonts.googleapis.com/css2?family=Anton&display=swap");
@import url("https://fonts.googleapis.com/css2?family=Anton&family=Montserrat:wght@500&display=swap");
</style>