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
    token: currentToken || '',
    user: currentUser || {},
    cuisines: {
      1: {
        displayValue: "Afghan",
        searchValue: "afghani",
      },
      2: {
        displayValue: "African",
        searchValue: "african"
      },
      3: {
        displayValue: "Senegalese",
        searchValue: "senegalese",
      },
      4: {
        displayValue: "South African",
        searchValue: "southafrican",
      },
      5: {
        displayValue: "New American",
        searchValue: "newamerican",
      },
      6: {
        displayValue: "Traditional American",
        searchValue: "tradamerican",
      },
      7: {
        displayValue: "Arabian",
        searchValue: "arabian",
      },
      8: {
        displayValue: "Argentine",
        searchValue: "argentine",
      },
      9: {
        displayValue: "Armenian",
        searchValue: "armenian",
      },
      10: {
        displayValue: "Asian Fusion",
        searchValue: "asianfusion",
      },
      11: {
        displayValue: "Australian",
        searchValue: "australian",
      },
      12: {
        displayValue: "Austrian",
        searchValue: "austrian",
      },
      13: {
        displayValue: "Bangladeshi",
        searchValue: "bangladeshi",
      },
      14: {
        displayValue: "Barbeque",
        searchValue: "bbq"
      },
      15: {
        displayValue: "Basque",
        searchValue: "basque",
      },
      16: {
        displayValue: "Belgian",
        searchValue: "belgian",
      },
      17: {
        displayValue: "Brasseries",
        searchValue: "brasseries",
      },
      18: {
        displayValue: "Brazilian",
        searchValue: "brazilian",
      },
      19: {
        displayValue: "Breakfast & Brunch",
        searchValue: "breakfast_brunch",
      },
      20: {
        displayValue: "Pancakes",
        searchValue: "pancakes",
      },
      21: {
        displayValue: "British",
        searchValue: "british",
      },
      22: {
        displayValue: "Buffets",
        searchValue: "buffets",
      },
      23: {
        displayValue: "Bulgarian",
        searchValue: "bulgarian",
      },
      24: {
        displayValue: "Burgers",
        searchValue: "burgers",
      },
      25: {
        displayValue: "Burmese",
        searchValue: "burmese",
      },
      26: {
        displayValue: "Cafes",
        searchValue: "cafes",
      },
      27: {
        displayValue: "Themed Cafes",
        searchValue: "themedcafes",
      },
      28: {
        displayValue: "Cafeteria",
        searchValue: "cafeteria",
      },
      29: {
        displayValue: "Cajun/Creole",
        searchValue: "cajun",
      },
      30: {
        displayValue: "Cambodian",
        searchValue: "cambodian",
      },
      31: {
        displayValue: "Caribbean",
        searchValue: "caribbean",
      },
      32: {
        displayValue: "Dominican",
        searchValue: "dominican",
      },
      33: {
        displayValue: "Haitian",
        searchValue: "haitian"
      },
      34: {
        displayValue: "Puerto Rican",
        searchValue: "puertorican",
      },
      35: {
        displayValue: "Trinidadian",
        searchValue: "trinidadian",
      },
      36: {
        displayValue: "Catalan",
        searchValue: "catalan",
      },
      37: {
        displayValue: "Cheesesteaks",
        searchValue: "cheesesteaks",
      },
      38: {
        displayValue: "Chicken Shop",
        searchValue: "chickenshop",
      },
      39: {
        displayValue: "Chicken Wings",
        searchValue: "chicken_wings",
      },
      40: {
        displayValue: "Chinese",
        searchValue: "chinese",
      },
      41: {
        displayValue: "Cantonese",
        searchValue: "cantonese",
      },
      42: {
        displayValue: "Dim Sum",
        searchValue: "dimsum",
      },
      43: {
        displayValue: "Hainan",
        searchValue: "hainan",
      },
      44: {
        displayValue: "Shanghainese",
        searchValue: "shanghainese",
      },
      45: {
        displayValue: "Szechuan",
        searchValue: "szechuan",
      },
      46: {
        displayValue: "Comfort Food",
        searchValue: "comfortfood",
      },
      47: {
        displayValue: "Creperies",
        searchValue: "creperies",
      },
      48: {
        displayValue: "Cuban",
        searchValue: "cuban",
      },
      49: {
        displayValue: "Czech",
        searchValue: "czech",
      },
      50: {
        displayValue: "Delis",
        searchValue: "delis",
      },
      51: {
        displayValue: "Diners",
        searchValue: "diners",
      },
      52: {
        displayValue: "Dinner Theater",
        searchValue: "dinnertheater",
      },
      53: {
        displayValue: "Eritrean",
        searchValue: "eritrean",
      },
      54: {
        displayValue: "Ethiopian",
        searchValue: "ethiopian",
      },
      55: {
        displayValue: "Fast Food",
        searchValue: "hotdogs",
      },
      56: {
        displayValue: "Filipino",
        searchValue: "filipino",
      },
      57: {
        displayValue: "Fish & Chips",
        searchValue: "fishnchips",
      },
      58: {
        displayValue: "Fondue",
        searchValue: "fondue",
      },
      59: {
        displayValue: "Food Court",
        searchValue: "food_court",
      },
      60: {
        displayValue: "Food Stands",
        searchValue: "foodstands",
      },
      61: {
        displayValue: "French",
        searchValue: "french",
      },
      62: {
        displayValue: "Mauritius",
        searchValue: "mauritius",
      },
      63: {
        displayValue: "Reunion",
        searchValue: "reunion",
      },
      64: {
        displayValue: "Game Meat",
        searchValue: "gamemeat",
      },
      65: {
        displayValue: "Gastropubs",
        searchValue: "gastropubs",
      },
      66: {
        displayValue: "Georgian",
        searchValue: "georgian",
      },
      67: {
        displayValue: "German",
        searchValue: "german",
      },
      68: {
        displayValue: "Gluten-Free",
        searchValue: "gluten_free",
      },
      69: {
        displayValue: "Greek",
        searchValue: "greek",
      },
      70: {
        displayValue: "Guamanian",
        searchValue: "guamanian",
      },
      71: {
        displayValue: "Halal",
        searchValue: "halal",
      },
      72: {
        displayValue: "Hawaiian",
        searchValue: "hawaiian",
      },
      73: {
        displayValue: "Himalayan/Nepalese",
        searchValue: "himalayan",
      },
      74: {
        displayValue: "Honduran",
        searchValue: "honduran",
      },
      75: {
        displayValue: "Hong Kong Style Cafe",
        searchValue: "hkcafe",
      },
      76: {
        displayValue: "Hot Dogs",
        searchValue: "hotdog",
      },
      77: {
        displayValue: "Hot Pot",
        searchValue: "hotpot",
      },
      78: {
        displayValue: "Hungarian",
        searchValue: "hungarian",
      },
      79: {
        displayValue: "Iberian",
        searchValue: "iberian",
      },
      80: {
        displayValue: "Indian",
        searchValue: "indpak",
      },
      81: {
        displayValue: "Indonesian",
        searchValue: "indonesian",
      },
      82: {
        displayValue: "Irish",
        searchValue: "irish",
      },
      83: {
        displayValue: "Italian",
        searchValue: "italian",
      },
      84: {
        displayValue: "Calabrian",
        searchValue: "calabrian",
      },
      85: {
        displayValue: "Sardinian",
        searchValue: "sardinian",
      },
      86: {
        displayValue: "Sicilian",
        searchValue: "sicilian",
      },
      87: {
        displayValue: "Tuscan",
        searchValue: "tuscan",
      },
      88: {
        displayValue: "Japanese",
        searchValue: "japanese",
      },
      89: {
        displayValue: "Conveyor Belt Sushi",
        searchValue: "conveyorsushi",
      },
      90: {
        displayValue: "Izakaya",
        searchValue: "izakaya",
      },
      91: {
        displayValue: "Japanese Curry",
        searchValue: "japacurry",
      },
      92: {
        displayValue: "Ramen",
        searchValue: "ramen",
      },
      93: {
        displayValue: "Teppanyaki",
        searchValue: "teppanyaki",
      },
      94: {
        displayValue: "Kebab",
        searchValue: "kebab",
      },
      95: {
        displayValue: "Korean",
        searchValue: "korean",
      },
      96: {
        displayValue: "Kosher",
        searchValue: "kosher",
      },
      97: {
        displayValue: "Laotian",
        searchValue: "laotian",
      },
      98: {
        displayValue: "Latin American",
        searchValue: "latin",
      },
      99: {
        displayValue: "Colombian",
        searchValue: "colombian",
      },
      100: {
        displayValue: "Salvadoran",
        searchValue: "salvadoran",
      },
      101: {
        displayValue: "Venezuelan",
        searchValue: "venezuelan",
      },
      102: {
        displayValue: "Live/Raw Food",
        searchValue: "raw_food",
      },
      103: {
        displayValue: "Malaysian",
        searchValue: "malaysian",
      },
      104: {
        displayValue: "Mediterranean",
        searchValue: "mediterranean",
      },
      105: {
        displayValue: "Falafel",
        searchValue: "falafel",
      },
      106: {
        displayValue: "Mexican",
        searchValue: "mexican",
      },
      107: {
        displayValue: "Tacos",
        searchValue: "tacos",
      },
      108: {
        displayValue: "Middle Eastern",
        searchValue: "mideastern",
      },
      109: {
        displayValue: "Egyptian",
        searchValue: "egyptian",
      },
      110: {
        displayValue: "Lebanese",
        searchValue: "lebanese",
      },
      111: {
        displayValue: "Modern European",
        searchValue: "modern_european",
      },
      112: {
        displayValue: "Mongolian",
        searchValue: "mongolian",
      },
      113: {
        displayValue: "Moroccan",
        searchValue: "moroccan",
      },
      114: {
        displayValue: "New Mexican Cuisine",
        searchValue: "newmexican",
      },
      115: {
        displayValue: "Nicaraguan",
        searchValue: "nicaraguan",
      },
      116: {
        displayValue: "Noodles",
        searchValue: "noodles",
      },
      117: {
        displayValue: "Pakistani",
        searchValue: "pakistani",
      },
      118: {
        displayValue: "Pan Asian",
        searchValue: "panasian",
      },
      119: {
        displayValue: "Persian/Iranian",
        searchValue: "persian",
      },
      120: {
        displayValue: "Peruvian",
        searchValue: "peruvian",
      },
      121: {
        displayValue: "Pizza",
        searchValue: "pizza",
      },
      122: {
        displayValue: "Polish",
        searchValue: "polish",
      },
      123: {
        displayValue: "Polynesian",
        searchValue: "polynesian",
      },
      124: {
        displayValue: "Pop-Up Restaurants",
        searchValue: "popuprestaurants",
      },
      125: {
        displayValue: "Portuguese",
        searchValue: "portuguese",
      },
      126: {
        displayValue: "Poutineries",
        searchValue: "poutineries",
      },
      127: {
        displayValue: "Russian",
        searchValue: "russian",
      },
      128: {
        displayValue: "Salad",
        searchValue: "salad",
      },
      129: {
        displayValue: "Sandwiches",
        searchValue: "sandwiches",
      },
      130: {
        displayValue: "Scandinavian",
        searchValue: "scandinavian",
      },
      131: {
        displayValue: "Scottish",
        searchValue: "scottish",
      },
      132: {
        displayValue: "Seafood",
        searchValue: "seafood",
      },
      133: {
        displayValue: "Singaporean",
        searchValue: "singaporean",
      },
      134: {
        displayValue: "Slovakian",
        searchValue: "slovakian",
      },
      135: {
        displayValue: "Somali",
        searchValue: "somali",
      },
      136: {
        displayValue: "Soul Food",
        searchValue: "soulfood",
      },
      137: {
        displayValue: "Soup",
        searchValue: "soup",
      },
      138: {
        displayValue: "Southern",
        searchValue: "southern",
      },
      139: {
        displayValue: "Spanish",
        searchValue: "spanish",
      },
      140: {
        displayValue: "Sri Lankan",
        searchValue: "srilankan",
      },
      141: {
        displayValue: "Steakhouses",
        searchValue: "steak",
      },
      142: {
        displayValue: "Supper Clubs",
        searchValue: "supperclubs",
      },
      143: {
        displayValue: "Sushi Bars",
        searchValue: "sushi",
      },
      145: {
        displayValue: "Syrian",
        searchValue: "syrian",
      },
      146: {
        displayValue: "Taiwanese",
        searchValue: "taiwanese",
      },
      147: {
        displayValue: "Tapas Bars",
        searchValue: "tapas",
      },
      148: {
        displayValue: "Tapas/Small Plates",
        searchValue: "tapasmallplates",
      },
      149: {
        displayValue: "Tex-Mex",
        searchValue: "tex-mex",
      },
      150: {
        displayValue: "Thai",
        searchValue: "thai",
      },
      151: {
        displayValue: "Turkish",
        searchValue: "turkish",
      },
      152: {
        displayValue: "Ukrainian",
        searchValue: "ukrainian",
      },
      153: {
        displayValue: "Uzbek",
        searchValue: "uzbek",
      },
      154: {
        displayValue: "Vegan",
        searchValue: "vegan",
      },
      155: {
        displayValue: "Vegetarian",
        searchValue: "vegetarian",
      },
      156: {
        displayValue: "Vietnamese",
        searchValue: "vietnamese",
      },
      157: {
        displayValue: "Waffles",
        searchValue: "waffles",
      },
      158: {
        displayValue: "Wraps",
        searchValue: "wraps",
      },
    },
  },
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
    }
  }
})
