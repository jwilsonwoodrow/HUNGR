using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RestaurantController : Controller
    {
        [HttpGet]
        public IActionResult getListOfRestaurantsLocationOnly(string location)
        {
            RestClient client = new RestClient("https://api.yelp.com/v3/businesses");

            client.Authenticator = new JwtAuthenticator("eaVrnAmbrpSFr42hRsFbG7_Ip2Vaawgjy31hbv_eEU1FK-2yftcNtIp3lDDXfhz_jiodk8M0Tam8kwbAHRI2NIyq804Qw69aarkeS-cQt4JFS_5cgewRD7j_HrZtYHYx");

            RestRequest request = new RestRequest($"/search?location={location}&term=restaurants");

            IRestResponse<Object> response = client.Get<Object>(request);
            // yelp returns a json, need to create a model that matches json object


            return Ok(response.Data);
        }

        [HttpGet]
        public IActionResult getListOfRestaurantsLocationAndType(string location, string category)
        {
            RestClient client = new RestClient("https://api.yelp.com/v3/businesses");

            client.Authenticator = new JwtAuthenticator("eaVrnAmbrpSFr42hRsFbG7_Ip2Vaawgjy31hbv_eEU1FK-2yftcNtIp3lDDXfhz_jiodk8M0Tam8kwbAHRI2NIyq804Qw69aarkeS-cQt4JFS_5cgewRD7j_HrZtYHYx");

            RestRequest request = new RestRequest($"/search?location={location}&term=restaurants");

            IRestResponse<Object> response = client.Get<Object>(request);
        }
    };
}
