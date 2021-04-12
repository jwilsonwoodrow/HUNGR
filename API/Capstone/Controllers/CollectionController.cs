using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("/collections")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly IRestaurantDAO restaurantDAO;

        public CollectionsController(IRestaurantDAO _restaurantDAO)
        {
            restaurantDAO = _restaurantDAO;
        }

        [HttpGet]
        public ActionResult<List<Restaurant>> GetCollection(string email)
        {
            List<Restaurant> collection = restaurantDAO.GetCollectionByUserEmail(email);

            if (collection != null)
            {
                return collection;
            } else
            {
                return NotFound();
            }

            
        }

        [HttpPost]
        public IActionResult SaveRestaurant(Restaurant restaurant)
        {
            //saved_restaurants

            Restaurant newRestaurant = restaurantDAO.AddRestaurant(restaurant.YelpRestaurantId, restaurant.RestaurantName, restaurant.RestaurantStreetAddress, restaurant.RestaurantCity, restaurant.RestaurantState, restaurant.RestaurantZip, restaurant.Category, restaurant.PhoneNumber);
            if (newRestaurant != null)
            {
                return Created(restaurant.YelpRestaurantId, null);
            }
            else
            {
                return BadRequest(new { message = "An error occurred and the restaurant was not saved." });
            }
        }

        [HttpPost]
        public IActionResult AddRestaurantToCollection(UserRestaurants userRest)
        {
            //user_restaurants
            List<Restaurant> collection = restaurantDAO.AddRestaurantToCollection(userRest.Email, userRest.RestaurantName);
            if (collection != null)
            {
                return Created(restaurantDAO.GetRestaurantByName(userRest.RestaurantName).RestaurantName, null);
            }
            else
            {
                return BadRequest(new { message = "An error occurred and the restaurant was not added to the collection." });
            }
        }
    }
}
