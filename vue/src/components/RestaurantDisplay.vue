<template>
  <div>
    <div
      class="restaurant-list"
      v-for="restaurant in $store.state.returnedRestaurants.businesses"
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
          {{ restaurant.name }}<br>{{ restaurant.display_phone }}<br>{{ restaurant.location.address1}}<br>{{ restaurant.location.city}}, {{ restaurant.location.state}} {{ restaurant.location.zip_code}}<br>{{ restaurant.is_closed}}
        </td>
        <td>
          <button @click="getRestaurantHours(restaurant.id)"> </button>
        </td>
      </tr>
    </div>
  </div>
</template>

<script>
export default {
  name: "restaurant-display",
  components: {},
  data() {
    return {
      hoursOfOperation: [
        {
          dayID: 6,
          dayOfWeek: "Sunday",
          openTime: 0,
          closeTime: 0
        },
        {
          dayID: 0,
          dayOfWeek: "Monday",
          openTime: 0,
          closeTime: 0
        },
        {
          dayID: 1,
          dayOfWeek: "Tuesday",
          openTime: 0,
          closeTime: 0
        },
        {
          dayID: 2,
          dayOfWeek: "Wednesday",
          openTime: 0,
          closeTime: 0
        },
        {
          dayID: 3,
          dayOfWeek: "Thursday",
          openTime: 0,
          closeTime: 0
        },
        {
          dayID: 4,
          dayOfWeek: "Friday",
          openTime: 0,
          closeTime: 0
        },
        {
          dayID: 5,
          dayOfWeek: "Saturday",
          openTime: 0,
          closeTime: 0
        },
        
      ]
    };
  },
  methods: {
    getRestaurantHours(restaurantId){
      apiService.getBusinessByID(restaurantId)
        .then(response => {
          response.
        })
    }
  },
  created() {
    //this.restaurantList = this.$store.returnedRestaurants
  },
};
</script>

<style>
</style>