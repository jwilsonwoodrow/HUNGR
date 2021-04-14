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
        public bool SaveRestaurantLikesDislikesByRestId(int restId, int numOfLikes, int numOfDislikes)
        {
            int rowsAffected = 0;
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO restaurant_likes_dislikes(restaurant_id, num_of_likes, num_of_dislikes)" +
                        " VALUES (restaurant_id = @restId, number_of_likes = @numOfLikes, number_of_dislikes = @numOfDislikes);", conn);
                    cmd.Parameters.AddWithValue("@restId", restId);
                    cmd.Parameters.AddWithValue("@numOfLikes", numOfLikes);
                    cmd.Parameters.AddWithValue("@numOfLikes", numOfDislikes);
                    rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return result;
        }
        public List<RestaurantLikesDislikes> GetInvitesByInviteId(int inviteId)
        {
            List<RestaurantLikesDislikes> inviteRestLikeDislike = new List<RestaurantLikesDislikes>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select invites.invite_id, invites.invite_title, invites.expiry_date, invites.event_date, saved_restaurants.restaurant_id, saved_restaurants.yelp_restaurant_id, saved_restaurants.restaurant_name, saved_restaurants.restaurant_address, saved_restaurants.restaurant_city," +
                        " saved_restaurants.restaurant_state, saved_restaurants.restaurant_zip_code, saved_restaurants.category, saved_restaurants.phone_number, restaurant_likes_dislikes.num_of_dislikes, restaurant_likes_dislikes.num_of_likes" +
                        " FROM saved_restaurants" +
                        " JOIN invite_restaurants ON invite_restaurants.restaurant_id = saved_restaurants.restaurant_id" +
                        " JOIN restaurant_likes_dislikes ON restaurant_likes_dislikes.restaurant_id = invite_restaurants.restaurant_id" +
                        " JOIN invites ON invites.invite_id = invite_restaurants.invite_id" +
                        " where invites.invite_id = @inviteId", conn);
                    cmd.Parameters.AddWithValue("@inviteId", inviteId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        inviteRestLikeDislike.Add(GetInviteRestLikesDislikesFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return inviteRestLikeDislike;
        }

        public bool UpdateLikesDislikesByRestId(int restId, int numOfLikes, int numOfDislikes)
        {
            int rowsAffected = 0;
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE restaurant_likes_dislikes SET num_of_dislikes = @numOfDislikes, num_of_likes = @numOfLikes WHERE restaurant_id = @restId", conn);
                    cmd.Parameters.AddWithValue("@restId", restId);
                    cmd.Parameters.AddWithValue("@numOfLikes", numOfLikes);
                    cmd.Parameters.AddWithValue("@numOfLikes", numOfDislikes);
                    rowsAffected = cmd.ExecuteNonQuery();

                    if(rowsAffected > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return result;
        }
        private RestaurantLikesDislikes GetInviteRestLikesDislikesFromReader(SqlDataReader reader)
        {
            RestaurantLikesDislikes inviteRestLikeDislike = new RestaurantLikesDislikes()
            {
                InviteTitle = Convert.ToString(reader["invite_title"]),
                InviteId = Convert.ToInt32(reader["invite_id"]),
                ExpiryDate = Convert.ToDateTime(reader["expiry_date"]),
                EventDate = Convert.ToDateTime(reader["event_date"]),
                RestaurantId = Convert.ToInt32(reader["restaurant_id"]),
                YelpRestaurantId = Convert.ToString(reader["yelp_restaurant_id"]),
                RestaurantName = Convert.ToString(reader["restaurant_name"]),
                RestaurantStreetAddress = Convert.ToString(reader["restaurant_address"]),
                RestaurantCity = Convert.ToString(reader["restaurant_city"]),
                RestaurantState = Convert.ToString(reader["restaurant_state"]),
                RestaurantZip = Convert.ToString(reader["restaurant_zip_code"]),
                Category = Convert.ToString(reader["category"]),
                PhoneNumber = Convert.ToString(reader["phone_number"]),
                NumOfDislikes = Convert.ToInt32(reader["rld.num_of_dislikes"]),
                NumOfLikes = Convert.ToInt32(reader["rld.num_of_likes"]),
            };

            return inviteRestLikeDislike;
        }
    }
}
