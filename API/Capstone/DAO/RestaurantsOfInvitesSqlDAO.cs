using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class RestaurantsOfInvitesSqlDAO : IRestaurantsOfInvitesSqlDAO
    {
        private readonly string connectionString;

        public RestaurantsOfInvitesSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<RestaurantsOfInvites> GetInvitesByUserId(int userId)
        {
            List<RestaurantsOfInvites> listOfInvites = new List<RestaurantsOfInvites>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select invites.invite_id, invites.invite_title, invites.expiry_date, invites.event_date, saved_restaurants.restaurant_id, saved_restaurants.yelp_restaurant_id, saved_restaurants.restaurant_name, saved_restaurants.restaurant_address, saved_restaurants.restaurant_city, " +
                        " saved_restaurants.restaurant_state, saved_restaurants.restaurant_zip_code, saved_restaurants.category, saved_restaurants.phone_number" +
                        " FROM saved_restaurants" +
                        " JOIN invite_restaurants ON invite_restaurants.restaurant_id = saved_restaurants.restaurant_id" +
                        " JOIN invites ON invites.invite_id = invite_restaurants.invite_id" +
                        " where invites.user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.HasRows && reader.Read())
                    {
                        listOfInvites.Add(GetFullInviteFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return listOfInvites;
        }
        private RestaurantsOfInvites GetFullInviteFromReader(SqlDataReader reader)
        {
            RestaurantsOfInvites fullInvite = new RestaurantsOfInvites()
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
                //PhotoUrl = Convert.ToString(reader["photo_url"]),
            };

            return fullInvite;
        }
        //private RestaurantsOfInvites GetFullInviteFromReader(SqlDataReader reader)
        //{
        //    RestaurantsOfInvites fullInvite = new RestaurantsOfInvites()
        //    {
        //        InviteTitle = Convert.ToString(reader["invites.invite_title"]),
        //        InviteId = Convert.ToInt32(reader["invites.invite_id"]),
        //        ExpiryDate = Convert.ToDateTime(reader["expiry_date"]),
        //        EventDate = Convert.ToDateTime(reader["event_date"]),
        //        RestaurantId = Convert.ToInt32(reader["saved_restaurants.restaurant_id"]),
        //        YelpRestaurantId = Convert.ToString(reader["saved_restaurants.yelp_restaurant_id"]),
        //        RestaurantName = Convert.ToString(reader["saved_restaurants.restaurant_name"]),
        //        RestaurantStreetAddress = Convert.ToString(reader["saved_restaurants.restaurant_address"]),
        //        RestaurantCity = Convert.ToString(reader["saved_restaurants.restaurant_city"]),
        //        RestaurantState = Convert.ToString(reader["saved_restaurants.restaurant_state"]),
        //        RestaurantZip = Convert.ToString(reader["saved_restaurants.restaurant_zip_code"]),
        //        Category = Convert.ToString(reader["saved_restaurants.category"]),
        //        PhoneNumber = Convert.ToString(reader["saved_restaurants.phone_number"]),
        //        PhotoUrl = Convert.ToString(reader["saved_restaurants.photo_url"]),
        //    };

        //    return fullInvite;
        //}
    }
}
