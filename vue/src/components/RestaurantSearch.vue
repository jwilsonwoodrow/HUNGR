<template>
  <div>
    <input type="search" placeholder="Type City or Zip" v-model="location" />
    <v-select
      label="displayValue"
      :options="cuisines"
      :value="selectedCuisine"
      @input= "cuisine => SelectCuisine(cuisine)" 
    />
  </div>
</template>

<script>
//import apiService from "../services/apiService";
import vSelect from "vue-select";

export default {
  name: "restaurant-search",
  components: { vSelect },
  data() {
    return {
      location: "",
      category: "",
      selectedCuisine: "",
      cuisines: [],
      stuff: [
        {
          uuid: "58dc3c76c9205670b433e934",
          email: "dennisingram@cinesanct.com",
        },
        {
          uuid: "58dc3c76fb733629909f1ce8",
          email: "louhendricks@zytrac.com",
        },
        {
          uuid: "58dc3c762d5b19946660567e",
          email: "cindyholcomb@tourmania.com",
        },
      ],
    };
  },
  created() {
    //apiService.getBusinessByLocationAndOrCategory(this.$);
    this.cuisines = this.$store.state.cuisines;
  },
  computed: {},
  methods: {
    SelectCuisine(cuisine) {
      this.SelectCuisine = cuisine;
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