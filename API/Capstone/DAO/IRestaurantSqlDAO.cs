using Capstone.Models;

namespace Capstone.DAO
{
    public interface IRestaurantSqlDAO
    {
        Restaurant AddRestaurant(int restId, string yelpId, string name, string address, string city, string state, string zip, string category, string phoneNum);
        Restaurant GetRestaurantByName(string name);
        Restaurant GetRestaurantByYelpId(string yelpId);
    }
}