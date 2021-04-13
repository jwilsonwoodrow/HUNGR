using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string YelpRestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantStreetAddress { get; set; }
        public string RestaurantCity { get; set; }
        public string RestaurantState { get; set; }
        public string RestaurantZip { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class RestaurantLikesDislikes
    {
        public int RestaurantId { get; set; }
        public int NumOfLikes { get; set; }
        public int NumOfDislikes { get; set; }
    }
    public class InviteRestaurant
    {
        public string PhotoUrl { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantStreetAddress { get; set; }
        public string RestaurantCity { get; set; }
        public string RestaurantState { get; set; }
        public string RestaurantZip { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }
    }
}
