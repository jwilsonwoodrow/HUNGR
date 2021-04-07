import axios from 'axios';

const http = axios.create({
    baseURL: 'https://api.yelp.com/v3/businesses',

  });

export default {

    resourceURL: "/search?location={{location}}&term=restaurants",
    
    //Gives all other data?
    getListOfBusinessesByLocation(location) {
       return http.get(`/search?location=${location}&term=restaurants`);

    },
    //Returns hours of operation (in military time)
    getBusinessByID(id) {
        return http.get(`${id}`);
    },

    //search location AND category if you want
    getBusinessByLocationAndOrCategory(location, category) {
        let url = this.resourceURL.replace('{{location}}', location); 
        if(category){
            url += `&categories=${category}`;
        }
       return http.get(url);

    },

     
     
}


