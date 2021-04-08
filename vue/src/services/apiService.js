import axios from 'axios';

//let apiKey = 'eaVrnAmbrpSFr42hRsFbG7_Ip2Vaawgjy31hbv_eEU1FK-2yftcNtIp3lDDXfhz_jiodk8M0Tam8kwbAHRI2NIyq804Qw69aarkeS-cQt4JFS_5cgewRD7j_HrZtYHYx'
const http = axios.create({
    //baseURL: 'https://api.yelp.com/v3/businesses',
    baseURL: 'https://localhost:44315/'
});

export default {

    //resourceURL: "/search?location={{location}}&term=restaurants",
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
    getBusinessByLocationAndCategory(location, category) {
        return http.get(`restaurant?location=${location}&term=restaurants&categories=${category}`)

    },

}


