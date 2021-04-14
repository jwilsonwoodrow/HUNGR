using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class RestaurantFavoritesSqlDAO : IRestaurantFavoritesSqlDAO
    {
        private readonly string connectionString;

        public RestaurantFavoritesSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<RestaurantLikesDislikes> GetRestaurantLIkesDislikesByInviteId(int inviteId)
        {
            List<RestaurantLikesDislikes> restaurantsLikesDislikes = new List<RestaurantLikesDislikes>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select sr.photo_url, sr.yelp_restaurant_id, sr.restaurant_name, sr.restaurant_address, sr.restaurant_city, sr.restaurant_state, sr.restaurant_zip_code, sr.category, sr.phone_number, rld.num_of_likes, rld.num_of_dislikes FROM saved_restaurants sr JOIN restaurant_likes_dislikes rld ON rld.restaurant_id = sr.restaurant_id JOIN invite_restaurants ir ON ir.restaurant_id = sr.restaurant_id WHERE ir.invite_id = @inviteId;", conn);
                    cmd.Parameters.AddWithValue("@inviteId", inviteId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        restaurantsLikesDislikes.Add(GetRestaurantLikeDislikeFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return restaurantsLikesDislikes;
        }
        private RestaurantLikesDislikes GetRestaurantLikeDislikeFromReader(SqlDataReader reader)
        {
            RestaurantLikesDislikes restaurantLikeDislike = new RestaurantLikesDislikes()
            {
                RestaurantId = Convert.ToInt32(reader["sr.restaurant_id"]),
                YelpRestaurantId = Convert.ToString(reader["sr.yelp_restaurant_id"]),
                PhotoUrl = Convert.ToString(reader["sr.photo_url"]),
                RestaurantName = Convert.ToString(reader["sr.restaurant_name"]),
                RestaurantStreetAddress = Convert.ToString(reader["sr.restaurant_address"]),
                RestaurantCity = Convert.ToString(reader["sr.restaurant_city"]),
                RestaurantState = Convert.ToString(reader["sr.restaurant_state"]),
                RestaurantZip = Convert.ToString(reader["sr.restaurant_zip_code"]),
                Category = Convert.ToString(reader["sr.category"]),
                PhoneNumber = Convert.ToString(reader["sr.phone_number"]),
                NumOfDislikes = Convert.ToInt32(reader["rld.num_of_dislikes"]),
                NumOfLikes = Convert.ToInt32(reader["rld.num_of_likes"]),
            };

            return restaurantLikeDislike;
        }
    }
}
