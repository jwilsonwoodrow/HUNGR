<template>
  <div class="body">
    <img class="backgroundLogo" src="https://www.linkpicture.com/q/bg4.png" />
    <input
      type="search"
      placeholder="Type City or Zip"
      v-model="location"
      class="location-input"
    /><br />
    <div class="dropdown">
      <input
        ref="dropdowninput"
        v-if="Object.keys(selectedCuisine).length === 0"
        v-model.trim="searchText"
        class="dropdown-input"
        type="text"
        placeholder="Search for Cuisine Type"
      />
      <div v-else @click="resetItem" class="dropdown-selected">
        {{ selectedCuisine.displayValue }}
      </div>
      <div class="dropdown-list" v-show="searchText">
        <div
          @click="selectItem(cuisine)"
          v-show="itemVisible(cuisine)"
          v-for="cuisine in cuisines"
          :key="cuisine.id"
          class="dropdown-item"
        >
          {{ cuisine.displayValue }}
        </div>
      </div>
    </div>
    <!-- <select v-model="selectedCuisine">
      <option value="" selected="selected" disabled>Select Cuisine Type</option>
      <option
        v-for="cuisine in cuisines"
        v-bind:key="cuisine.id"
        v-bind:value="cuisine.searchValue"
      >
        {{ cuisine.displayValue }}
      </option>
    </select> -->
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
  computed: {},
  methods: {
    getRestaurants() {
      if (this.selectedCuisine) {
        apiService
          .getBusinessByLocationAndCategory(
            this.location,
            this.selectedCuisine.searchValue
          )
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
    itemVisible(cuisine) {
      let currentName = cuisine.displayValue.toLowerCase();
      let currentInput = this.searchText.toLowerCase();
      return currentName.includes(currentInput);
    },
    selectItem(cuisine) {
      this.selectedCuisine = cuisine;
      this.searchText = "";
      this.$emit("on-item-selected", cuisine);
    },
    resetItem() {
      this.selectedCuisine = "";
      this.$nextTick(() => this.$refs.dropdowninput.focus());
      this.$emit("on-item-reset");
    },
  },
};
</script>
<style scoped>
.backgroundLogo {
  min-height: 100%;
  min-width: 1024px;
  width: 100%;
  height: auto;
  position: fixed;
  top: 0;
  left: 0;
  z-index: -1;
  background-size: cover;
}
/* Dropdown Button */
.dropbtn {
  background-color: #4caf50;
  color: white;
  padding: 16px;
  font-size: 16px;
  border: none;
}
.search-button {
  display: inline-block;
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
  margin-left: 60px;
  justify-content: center;
}
.dropdown {
  /* position: relative; */
  width: 85%;
  max-width: 400px;
  /* margin: 0 auto; */
  margin-right: 22.5%;
}
.dropdown-input,
.location-input,
.dropdown-selected {
  width: 82%;
  padding: 10px 16px;
  border: 1px solid transparent;
  background: rgb(252, 248, 200);
  line-height: 1.5em;
  outline: none;
  border-radius: 8px;
}
.dropdown-list {
  position: absolute;
  width: 55%;
  max-height: 500px;
  margin-top: 4px;
  overflow-y: auto;
  background: #ffffff;
  box-shadow: 0 10px 15px -3px rgba(0, 0, 0, 0.1),
    0 4px 6px -2px rgba(0, 0, 0, 0.05);
  border-radius: 8px;
  z-index: 1;
}
.dropdown-item,
.dropdown-list {
  background: rgb(252, 248, 200);
}
.location-input {
  margin-bottom: 5px;
  margin-left: 5px;
}
.dropdown-input:focus,
.dropdown-selected:hover {
  background: rgb(252, 248, 200);
  border-color: #e2e8f0;
}
.dropdown-selected {
  font-weight: bold;
  cursor: pointer;
  background: rgb(252, 248, 200);
}
.dropdown-item {
  display: flex;
  width: 100%;
  padding: 11px 16px;
  cursor: pointer;
}
.dropdown-item:hover {
  background: #edf2f7;
}
.dropdown-item-flag {
  max-width: 24px;
  max-height: 18px;
  margin: auto 12px auto 0px;
}
.body {
  padding-left: 25%;
  display: inline-block;
}
</style>