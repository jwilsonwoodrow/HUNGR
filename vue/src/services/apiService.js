import axios from 'axios';

const http = axios.create({
    baseURL: 'https://localhost:44315/'
});

export default {
    //resourceURL: 'restaurant?location={{location}}',

    //Gives all other data?
    getListOfBusinessesByLocation(location) {
        return http.get(`restaurant?location=${location}&term=restaurants`);
    },
    // HAVE TO CREATE NEW CONTROLLER for this
    //Returns hours of operation (in military time)
    getBusinessByID(id) {
        return http.get(`restaurantDetails?id=${id}`);
    },

    //search location AND category if you want
    getBusinessByLocationAndCategory(location, categories) {  //how do we give this its own route in the restaurant controller?
        return http.get(`restaurant?location=${location}&categories=${categories}`)
    },
    CreateEvent(invite) {
        return axios.post(`/invites/save`, invite);
    },
    CreateRestaurant(restaurants) {
        // Restaurant AddRestaurant(string yelpId, string name, string address, string city, string state, string zip, string category, string phoneNum);
        let exportRestaurants = [];
        restaurants.forEach(restaurant => {
            let currentRestaurant = {};
            currentRestaurant.restaurantName = restaurant.name;
            currentRestaurant.yelpRestaurantId = restaurant.id;
            currentRestaurant.restaurantCity = restaurant.location.city;
            currentRestaurant.restaurantState = restaurant.location.state;
            currentRestaurant.restaurantZip = restaurant.location.zip_code;
            currentRestaurant.category = restaurant.categories[0];
            currentRestaurant.phoneNumber = restaurant.displayPhone
            exportRestaurants.push(currentRestaurant);
        });
        return axios.post(`/restaurants`, exportRestaurants)
    },

    RelateEventRestaurant(invite_restaurants){
        return axios.post(`/invites/${invite_restaurants.inviteId}/restaurants`, invite_restaurants.restaurantIds)
    }
    // need invite id, title, current user id, rsvp datetime, event datetime
}


