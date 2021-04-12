using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRestaurantDAO
    {
        Restaurant AddRestaurant(string yelpId, string name, string address, string city, string state, string zip, string category, string phoneNum);
        Restaurant GetRestaurantByName(string name);
        Restaurant GetRestaurantByYelpId(string yelpId);
        List<Restaurant> GetCollectionByUserEmail(string email);
        List<Restaurant> AddRestaurantToCollection(string email, string restaurantName);
    }
}