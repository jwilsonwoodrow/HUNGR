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

        //[HttpPost]
        //public IActionResult SaveRestaurant(Restaurant restaurant, UserRestaurants userRest)
        //{
        //    //saved_restaurants

        //    Restaurant newRestaurant = restaurantDAO.AddRestaurant(restaurant.YelpRestaurantId, restaurant.RestaurantName, restaurant.RestaurantStreetAddress, restaurant.RestaurantCity, restaurant.RestaurantState, restaurant.RestaurantZip, restaurant.Category, restaurant.PhoneNumber);
        //    List<Restaurant> collection = restaurantDAO.AddRestaurantToCollection(userRest.Email, userRest.RestaurantName);
        //    if (newRestaurant != null && collection != null)
        //    {
        //        return Created(restaurant.YelpRestaurantId, null);
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = "An error occurred and the restaurant was not saved." });
        //    }
        //}
    }
}
