import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if (currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    savedRestaurants: [],
    token: currentToken || '',
    user: currentUser || {},
    returnedRestaurants: [],
    cuisines: [
        {
          id: 1,
          displayValue: "Afghan",
          searchValue: "afghani",
        },
        {
          id: 2,
          displayValue: "African",
          searchValue: "african"
        },
        {
          id: 3,
          displayValue: "Senegalese",
          searchValue: "senegalese",
        },
        {
          id: 4,
          displayValue: "South African",
          searchValue: "southafrican",
        },
        {
          id: 5,
          displayValue: "New American",
          searchValue: "newamerican",
        },
        {
          id: 6,
          displayValue: "Traditional American",
          searchValue: "tradamerican",
        },
        {
          id: 7,
          displayValue: "Arabian",
          searchValue: "arabian",
        },
        {
          id: 8,
          displayValue: "Argentine",
          searchValue: "argentine",
        },
        {
          id: 9,
          displayValue: "Armenian",
          searchValue: "armenian",
        },
        {
          id: 10,
          displayValue: "Asian Fusion",
          searchValue: "asianfusion",
        },
        {
          id: 11,
          displayValue: "Australian",
          searchValue: "australian",
        },
        {
          id: 12,
          displayValue: "Austrian",
          searchValue: "austrian",
        },
       {
          id: 13,
          displayValue: "Bangladeshi",
          searchValue: "bangladeshi",
        },
        {
          id: 14,
          displayValue: "Barbeque",
          searchValue: "bbq"
        },
        {
          id: 15,
          displayValue: "Basque",
          searchValue: "basque",
        },
        {
          id: 16,
          displayValue: "Belgian",
          searchValue: "belgian",
        },
        {
          id: 17,
          displayValue: "Brasseries",
          searchValue: "brasseries",
        },
        {
          id: 18,
          displayValue: "Brazilian",
          searchValue: "brazilian",
        },
        {
          id: 19,
          displayValue: "Breakfast & Brunch",
          searchValue: "breakfast_brunch",
        },
        {
          id: 20,
          displayValue: "Pancakes",
          searchValue: "pancakes",
        },
        {
          id: 21,
          displayValue: "British",
          searchValue: "british",
        },
        {
          id: 22,
          displayValue: "Buffets",
          searchValue: "buffets",
        },
        {
          id: 23,
          displayValue: "Bulgarian",
          searchValue: "bulgarian",
        },
        {
          id: 24,
          displayValue: "Burgers",
          searchValue: "burgers",
        },
        {
          id: 25,
          displayValue: "Burmese",
          searchValue: "burmese",
        },
        {
          id: 26,
          displayValue: "Cafes",
          searchValue: "cafes",
        },
        {
          id: 27,
          displayValue: "Themed Cafes",
          searchValue: "themedcafes",
        },
        {
          id: 28,
          displayValue: "Cafeteria",
          searchValue: "cafeteria",
        },
        {
          id: 29,
          displayValue: "Cajun/Creole",
          searchValue: "cajun",
        },
        {
          id: 30,
          displayValue: "Cambodian",
          searchValue: "cambodian",
        },
        {
          id: 31,
          displayValue: "Caribbean",
          searchValue: "caribbean",
        },
        {
          id: 32,
          displayValue: "Dominican",
          searchValue: "dominican",
        },
        {
          id: 33,
          displayValue: "Haitian",
          searchValue: "haitian"
        },
        {
          id: 34,
          displayValue: "Puerto Rican",
          searchValue: "puertorican",
        },
        {
          id: 35,
          displayValue: "Trinidadian",
          searchValue: "trinidadian",
        },
        {
          id: 36,
          displayValue: "Catalan",
          searchValue: "catalan",
        },
        {
          id: 37,
          displayValue: "Cheesesteaks",
          searchValue: "cheesesteaks",
        },
        {
          id: 38,
          displayValue: "Chicken Shop",
          searchValue: "chickenshop",
        },
        {
          id: 39,
          displayValue: "Chicken Wings",
          searchValue: "chicken_wings",
        },
        {
          id: 40,
          displayValue: "Chinese",
          searchValue: "chinese",
        },
        {
          id: 41,
          displayValue: "Cantonese",
          searchValue: "cantonese",
        },
        {
          id: 42,
          displayValue: "Dim Sum",
          searchValue: "dimsum",
        },
        {
          id: 43,
          displayValue: "Hainan",
          searchValue: "hainan",
        },
        {
          id: 44,
          displayValue: "Shanghainese",
          searchValue: "shanghainese",
        },
        {
          id: 45,
          displayValue: "Szechuan",
          searchValue: "szechuan",
        },
        {
          id: 46,
          displayValue: "Comfort Food",
          searchValue: "comfortfood",
        },
        {
          id: 47,
          displayValue: "Creperies",
          searchValue: "creperies",
        },
        {
          id: 48,
          displayValue: "Cuban",
          searchValue: "cuban",
        },
        {
          id: 49,
          displayValue: "Czech",
          searchValue: "czech",
        },
        {
          id: 50,
          displayValue: "Delis",
          searchValue: "delis",
        },
        {
          id: 51,
          displayValue: "Diners",
          searchValue: "diners",
        },
        {
          id: 52,
          displayValue: "Dinner Theater",
          searchValue: "dinnertheater",
        },
        {
          id: 53,
          displayValue: "Eritrean",
          searchValue: "eritrean",
        },
        {
          id: 54,
          displayValue: "Ethiopian",
          searchValue: "ethiopian",
        },
        {
          id: 55,
          displayValue: "Fast Food",
          searchValue: "hotdogs",
        },
        {
          id: 56,
          displayValue: "Filipino",
          searchValue: "filipino",
        },
        {
          id: 57,
          displayValue: "Fish & Chips",
          searchValue: "fishnchips",
        },
        {
          id: 58,
          displayValue: "Fondue",
          searchValue: "fondue",
        },
        {
          id: 59,
          displayValue: "Food Court",
          searchValue: "food_court",
        },
        {
          id: 60,
          displayValue: "Food Stands",
          searchValue: "foodstands",
        },
        {
          id: 61,
          displayValue: "French",
          searchValue: "french",
        },
        {
          id: 62,
          displayValue: "Mauritius",
          searchValue: "mauritius",
        },
        {
          id: 63,
          displayValue: "Reunion",
          searchValue: "reunion",
        },
        {
          id: 64,
          displayValue: "Game Meat",
          searchValue: "gamemeat",
        },
        {
          id: 65,
          displayValue: "Gastropubs",
          searchValue: "gastropubs",
        },
        {
          id: 66,
          displayValue: "Georgian",
          searchValue: "georgian",
        },
        {
          id: 67,
          displayValue: "German",
          searchValue: "german",
        },
        {
          id: 68,
          displayValue: "Gluten-Free",
          searchValue: "gluten_free",
        },
        {
          id: 69,
          displayValue: "Greek",
          searchValue: "greek",
        },
        {
          id: 70,
          displayValue: "Guamanian",
          searchValue: "guamanian",
        },
        {
          id: 71,
          displayValue: "Halal",
          searchValue: "halal",
        },
        {
          id: 72,
          displayValue: "Hawaiian",
          searchValue: "hawaiian",
        },
        {
          id: 73,
          displayValue: "Himalayan/Nepalese",
          searchValue: "himalayan",
        },
        {
          id: 74,
          displayValue: "Honduran",
          searchValue: "honduran",
        },
        {
          id: 75,
          displayValue: "Hong Kong Style Cafe",
          searchValue: "hkcafe",
        },
        {
          id: 76,
          displayValue: "Hot Dogs",
          searchValue: "hotdog",
        },
        {
          id: 77,
          displayValue: "Hot Pot",
          searchValue: "hotpot",
        },
        {
          id: 78,
          displayValue: "Hungarian",
          searchValue: "hungarian",
        },
        {
          id: 79,
          displayValue: "Iberian",
          searchValue: "iberian",
        },
        {
          id: 80,
          displayValue: "Indian",
          searchValue: "indpak",
        },
        {
          id: 81,
          displayValue: "Indonesian",
          searchValue: "indonesian",
        },
        {
          id: 82,
          displayValue: "Irish",
          searchValue: "irish",
        },
        {
          id: 83,
          displayValue: "Italian",
          searchValue: "italian",
        },
        {
          id: 84,
          displayValue: "Calabrian",
          searchValue: "calabrian",
        },
        {
          id: 85,
          displayValue: "Sardinian",
          searchValue: "sardinian",
        },
        {
          id: 86,
          displayValue: "Sicilian",
          searchValue: "sicilian",
        },
        {
          id: 87,
          displayValue: "Tuscan",
          searchValue: "tuscan",
        },
        {
          id: 88,
          displayValue: "Japanese",
          searchValue: "japanese",
        },
        {
          id: 89,
          displayValue: "Conveyor Belt Sushi",
          searchValue: "conveyorsushi",
        },
        {
          id: 90,
          displayValue: "Izakaya",
          searchValue: "izakaya",
        },
        {
          id: 91,
          displayValue: "Japanese Curry",
          searchValue: "japacurry",
        },
        {
          id: 92,
          displayValue: "Ramen",
          searchValue: "ramen",
        },
        {
          id: 93,
          displayValue: "Teppanyaki",
          searchValue: "teppanyaki",
        },
        {
          id: 94,
          displayValue: "Kebab",
          searchValue: "kebab",
        },
        {
          id: 95,
          displayValue: "Korean",
          searchValue: "korean",
        },
        {
          id: 96,
          displayValue: "Kosher",
          searchValue: "kosher",
        },
        {
          id: 97,
          displayValue: "Laotian",
          searchValue: "laotian",
        },
        {
          id: 98,
          displayValue: "Latin American",
          searchValue: "latin",
        },
        {
          id: 99,
          displayValue: "Colombian",
          searchValue: "colombian",
        },
        {
          id: 100,
          displayValue: "Salvadoran",
          searchValue: "salvadoran",
        },
        {
          id: 101,
          displayValue: "Venezuelan",
          searchValue: "venezuelan",
        },
        {
          id: 102,
          displayValue: "Live/Raw Food",
          searchValue: "raw_food",
        },
        {
          id: 103,
          displayValue: "Malaysian",
          searchValue: "malaysian",
        },
        {
          id: 104,
          displayValue: "Mediterranean",
          searchValue: "mediterranean",
        },
        {
          id: 105,
          displayValue: "Falafel",
          searchValue: "falafel",
        },
        {
          id: 106,
          displayValue: "Mexican",
          searchValue: "mexican",
        },
        {
          id: 107,
          displayValue: "Tacos",
          searchValue: "tacos",
        },
        {
          id: 108,
          displayValue: "Middle Eastern",
          searchValue: "mideastern",
        },
        {
          id: 109,
          displayValue: "Egyptian",
          searchValue: "egyptian",
        },
        {
          id: 110,
          displayValue: "Lebanese",
          searchValue: "lebanese",
        },
        {
          id: 111,
          displayValue: "Modern European",
          searchValue: "modern_european",
        },
        {
          id: 112,
          displayValue: "Mongolian",
          searchValue: "mongolian",
        },
        {
          id: 113,
          displayValue: "Moroccan",
          searchValue: "moroccan",
        },
        {
          id: 114,
          displayValue: "New Mexican Cuisine",
          searchValue: "newmexican",
        },
        {
          id: 115,
          displayValue: "Nicaraguan",
          searchValue: "nicaraguan",
        },
        {
          id: 116,
          displayValue: "Noodles",
          searchValue: "noodles",
        },
        {
          id: 117,
          displayValue: "Pakistani",
          searchValue: "pakistani",
        },
        {
          id: 118,
          displayValue: "Pan Asian",
          searchValue: "panasian",
        },
        {
          id: 119,
          displayValue: "Persian/Iranian",
          searchValue: "persian",
        },
        {
          id: 120,
          displayValue: "Peruvian",
          searchValue: "peruvian",
        },
        {
          id: 121,
          displayValue: "Pizza",
          searchValue: "pizza",
        },
        {
          id: 122,
          displayValue: "Polish",
          searchValue: "polish",
        },
        {
          id: 123,
          displayValue: "Polynesian",
          searchValue: "polynesian",
        },
        {
          id: 124,
          displayValue: "Pop-Up Restaurants",
          searchValue: "popuprestaurants",
        },
        {
          id: 125,
          displayValue: "Portuguese",
          searchValue: "portuguese",
        },
        {
          id: 126,
          displayValue: "Poutineries",
          searchValue: "poutineries",
        },
        {
          id: 127,
          displayValue: "Russian",
          searchValue: "russian",
        },
        {
          id: 128,
          displayValue: "Salad",
          searchValue: "salad",
        },
        {
          id: 129,
          displayValue: "Sandwiches",
          searchValue: "sandwiches",
        },
        {
          id: 130,
          displayValue: "Scandinavian",
          searchValue: "scandinavian",
        },
        {
          id: 131,
          displayValue: "Scottish",
          searchValue: "scottish",
        },
        {
          id: 132,
          displayValue: "Seafood",
          searchValue: "seafood",
        },
        {
          id: 133,
          displayValue: "Singaporean",
          searchValue: "singaporean",
        },
        {
          id: 134,
          displayValue: "Slovakian",
          searchValue: "slovakian",
        },
        {
          id: 135,
          displayValue: "Somali",
          searchValue: "somali",
        },
        {
          id: 136,
          displayValue: "Soul Food",
          searchValue: "soulfood",
        },
        {
          id: 137,
          displayValue: "Soup",
          searchValue: "soup",
        },
        {
          id: 138,
          displayValue: "Southern",
          searchValue: "southern",
        },
        {
          id: 139,
          displayValue: "Spanish",
          searchValue: "spanish",
        },
        {
          id: 140,
          displayValue: "Sri Lankan",
          searchValue: "srilankan",
        },
        {
          id: 141,
          displayValue: "Steakhouses",
          searchValue: "steak",
        },
        {
          id: 142,
          displayValue: "Supper Clubs",
          searchValue: "supperclubs",
        },
        {
          id: 143,
          displayValue: "Sushi Bars",
          searchValue: "sushi",
        },
        {
          id: 145,
          displayValue: "Syrian",
          searchValue: "syrian",
        },
        {
          id: 146,
          displayValue: "Taiwanese",
          searchValue: "taiwanese",
        },
        {
          id: 147,
          displayValue: "Tapas Bars",
          searchValue: "tapas",
        },
        {
          id: 148,
          displayValue: "Tapas/Small Plates",
          searchValue: "tapasmallplates",
        },
        {
          id: 149,
          displayValue: "Tex-Mex",
          searchValue: "tex-mex",
        },
        {
          id: 150,
          displayValue: "Thai",
          searchValue: "thai",
        },
        {
          id: 151,
          displayValue: "Turkish",
          searchValue: "turkish",
        },
        {
          id: 152,
          displayValue: "Ukrainian",
          searchValue: "ukrainian",
        },
        {
          id: 153,
          displayValue: "Uzbek",
          searchValue: "uzbek",
        },
        {
          id: 154,
          displayValue: "Vegan",
          searchValue: "vegan",
        },
        {
          id: 155,
          displayValue: "Vegetarian",
          searchValue: "vegetarian",
        },
        {
          id: 156,
          displayValue: "Vietnamese",
          searchValue: "vietnamese",
        },
        {
          id: 157,
          displayValue: "Waffles",
          searchValue: "waffles",
        },
        {
          id: 158,
          displayValue: "Wraps",
          searchValue: "wraps",
        },
      ]
    },
  store: {},
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user', JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    STORE_RETURNED_RESTAURANTS(state, restaurants) {
      state.returnedRestaurants = restaurants;
    },
    SAVE_RESTAURANT(state, restaurant){
      state.savedRestaurants.push(restaurant);
      console.log(state.savedRestaurants);
    },
    CLEAR_SAVED_RESTAURANTS(state){
      state.savedRestaurants = [];
      console.log(state.savedRestaurants)
    }
  }
})
