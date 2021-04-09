<template>
  <div>
    <div
      class="restaurant-list"
      v-for="(restaurant, index) in $store.state.returnedRestaurants.businesses"
      v-bind:key="restaurant.id"
      v-show="$store.state.returnedRestaurants"
    >
      <tr>
        <th></th>
        <th></th>
      </tr>
      <tr>
        <td>
          <img
            v-bind:src="restaurant.image_url"
            alt=""
            width="250"
            height="250"
          />
        </td>
        <td>
          {{ restaurant.name }}<br />{{ restaurant.display_phone }}<br />{{
            restaurant.location.address1
          }}<br />{{ restaurant.location.city }},
          {{ restaurant.location.state }} {{ restaurant.location.zip_code
          }}<br />{{ restaurant.is_closed }}
        </td>
        <td>
          <button @click="getRestaurantDetails(restaurant.id, index)"></button>
          <div v-show="displayDetails[index]">
            {{ rawDataDetails.hours }}
          </div>
        </td>
      </tr>
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
      displayDetails: [], //array of booleans, one for each displayed restaurant
      rawDataDetails: [],
      hoursOfOperation: [
        {
          dayID: 6,
          dayOfWeek: "Sunday",
          openTime: 0,
          closeTime: 0,
        },
        {
          dayID: 0,
          dayOfWeek: "Monday",
          openTime: 0,
          closeTime: 0,
        },
        {
          dayID: 1,
          dayOfWeek: "Tuesday",
          openTime: 0,
          closeTime: 0,
        },
        {
          dayID: 2,
          dayOfWeek: "Wednesday",
          openTime: 0,
          closeTime: 0,
        },
        {
          dayID: 3,
          dayOfWeek: "Thursday",
          openTime: 0,
          closeTime: 0,
        },
        {
          dayID: 4,
          dayOfWeek: "Friday",
          openTime: 0,
          closeTime: 0,
        },
        {
          dayID: 5,
          dayOfWeek: "Saturday",
          openTime: 0,
          closeTime: 0,
        },
      ],
    };
  },
  methods: {
    getRestaurantDetails(restaurantId, index) {
      if (this.displayDetails[index] === true) {
        this.displayDetails[index] = false;
      } else this.displayDetails[index] = true;
      apiService.getBusinessByID(restaurantId).then((response) => {
        this.rawDataDetails = response.data;
      });
    },
  },
  computed: {},
  updated() {
    console.log(this.$store.state.returnedRestaurants.businesses.length);
    for (let i = 0; i < this.$store.state.returnedRestaurants.businesses.length; i++) {
      this.displayDetails[i] = false;
    }
  },
};
</script>

<style>
</style>