import axios from 'axios';

const http = axios.create({
    baseURL: 'https://localhost:44315/'
});

export default {
    resourceURL: 'restaurant?location={{location}}',

    //Gives all other data?
    getListOfBusinessesByLocation(location) {
        return http.get(`restaurant?location=${location}&term=restaurants`);
    },
    // HAVE TO CREATE NEW CONTROLLER for this
    //Returns hours of operation (in military time)
    getBusinessByID(id) {
        return http.get(`${id}`, {
        });
    },

    //search location AND category if you want
    getBusinessByLocationAndCategory(location, categories) {  //how do we give this its own route in the restaurant controller?
        return http.get(`restaurant?location=${location}&categories=${categories}`)  
    },
}


