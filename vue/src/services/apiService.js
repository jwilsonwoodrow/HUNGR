import axios from 'axios';

 const http = axios.create({

     baseURL: 'https://us-restaurant-menus.p.rapidapi.com/restaurants'
 })


 export default {

     getRestaurantsByZip(zipCode) {
         return http.get(baseURL += `/zip_code/${zipCode}`)
     },

     
     
 }

