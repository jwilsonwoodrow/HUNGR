<template>
  <div>
    <table>
      <tr>
        <th><input type="search" placeholder="Type City or Zip" v-model="location" />
</th>
        <th>Select Cuisine</th>
      </tr>
      <tr>
        <td>{{ cuisine }}</td>
        <td>
          <v-select class="dropdown-content"
            :options=cuisines
            :value="cuisine"
            @input="(cuisine) => SelectCuisine(cuisine)"
          />
        </td>
      </tr>
    </table>
    <!-- <div class="dropdown">
      <button class="dropbtn">Select Cuisine Type</button>
      <div class="dropdown-content">
        <p v-for="cuisine in cuisines" v-bind:key="cuisine" @click="SelectCuisine"> {{cuisine}}
        </p>
      </div>
    </div>-->
  </div>
</template>

<script>
import apiService from "../services/apiService";
import vSelect from 'vue-select'

export default {
  name: "restaurant-search",
  components: {vSelect},
  data() {
    return {
      location: "",
      category: "",
      selectedCuisine: "",
      cuisines: [
        "Mexican",
        "French",
        "American",
        "Chinese",
        "Vietnamese",
        "Italian",
        "Korean",
        "Japanese",
        "Texmex",
        "Breakfast & Brunch",
        "Indian",
        "Mediterranean",
        "Polish",
        "Greek",
        "Middle-Eastern",
        "Lebanese",
        "Barbeque",
        "Thai",
        "Cupcakes",
        "Dessert",
        "Ethiopian",
        "Jamacian",
        "Caribbean",
        "Coffee",
        "Tea",
        "Bar",
        "Tavern",
        "Pizza",
      ],
    };
  },
  created() {
    apiService.getBusinessByLocationAndOrCategory(this.$);
  },
  computed: {
    options: () => this.cuisines,
  },
  methods: {
    SelectCuisine(cuisine) {
      this.selectedCuisines.push(cuisine);
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
.dropdown-content a:hover {
  background-color: red
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