<template>
  <div>
    <input type="search" placeholder="Type City or Zip" v-model="location" />
    <select v-model="selectedCuisine">
      <option disabled>Select One</option>
      <option
        v-for="cuisine in cuisines"
        v-bind:key="cuisine.id"
        v-bind:value="cuisine.searchValue"
      >
        {{ cuisine.displayValue }}
      </option>
    </select>
    <!-- 
      Potential Filtered search/drop down

      <div class="dropdown">
    <input type="text" v-model="searchText" />
    <pre>{{ matches.displayValue }}</pre>  </div> -->

    <button class="search-button" @click="getRestaurants()">Search</button>
  </div>
</template>

<script>
import apiService from "../services/apiService";

export default {
  name: "restaurant-search",
  components: {},
  data() {
    return {
      searchText: "",
      location: "",
      category: "",
      selectedCuisine: "",
      cuisines: [],
      returnedRestaurants: [],
    };
  },
  created() {
    this.cuisines = this.$store.state.cuisines;
  },
  computed: {
    //potential filtered search
    // matches () {
    //   return Object.entries(this.cuisines).filter((cuisine) => {
    //     var optionText = cuisine[0].toUpperCase()
    //     return optionText.match(this.searchText.toUpperCase())
    //   })
    // }
  },
  methods: {
    getRestaurants() {
      if (this.selectedCuisine) {
        apiService
          .getBusinessByLocationAndCategory(this.location, this.selectedCuisine)
          .then((resp) => {
            this.returnedRestaurants = resp.data;
            this.$store.commit(
              "STORE_RETURNED_RESTAURANTS",
              this.returnedRestaurants
            );
          });
      } else {
        apiService.getListOfBusinessesByLocation(this.location).then((resp) => {
          //console.log(resp.data.businesses)
          this.returnedRestaurants = resp.data;
          this.$store.commit(
            "STORE_RETURNED_RESTAURANTS",
            this.returnedRestaurants
          );
        });
      }
    },
  },
};
</script>

<style>
/* Dropdown Button */
.dropbtn {
  background-color: #4caf50;
  color: white;
  padding: 16px;
  font-size: 16px;
  border: none;
}
.search-button {
  font-family: "Montserrat", sans-serif;
  background: transparent;
  background-image: url("https://www.linkpicture.com/q/button-1_1.png");
  background-size: 75px 40px;
  font-weight: 10;
  width: 75px;
  height: 40px;
  font-size: 85%;
  color: rgb(253, 243, 155);
  border: 0;
  padding: 0;
}
/* The container <div> - needed to position the dropdown content */
.dropdown {
  position: relative;
  display: inline-block;
}

/* Dropdown Content (Hidden by Default) */
.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f1f1f1;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
  z-index: 1;
}

/* Links inside the dropdown */
.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
}

/* Change color of dropdown links on hover */
.dropdown-content tr:hover {
  background-color: red;
}

/* Show the dropdown menu on hover */
.dropdown:hover .dropdown-content {
  display: block;
}

/* Change the background color of the dropdown button when the dropdown content is shown */
.dropdown:hover .dropbtn {
  background-color: #3e8e41;
}
</style>