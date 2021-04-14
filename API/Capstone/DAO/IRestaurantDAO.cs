using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRestaurantDAO
    {
        int AddRestaurant(string photoUrl, string yelpId, string name, string address, string city, string state, string zip, string category, string phoneNum);
        Restaurant GetRestaurantById(int id);
        Restaurant GetRestaurantByYelpId(string yelpId);
        List<InviteRestaurant> GetRestaurantsByInviteId(int inviteId);
    }
}