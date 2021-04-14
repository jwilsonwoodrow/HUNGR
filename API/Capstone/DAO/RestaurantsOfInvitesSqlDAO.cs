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

                    SqlCommand cmd = new SqlCommand("Select i.invite_id, i.invite_title, i.expiry_date, i.event_date, sr.restaurant_id, sr.yelp_restaurant_id, sr.restaurant_name, sr.restaurant_address, sr.restaurant_city, " +
                        "sr.restaurant_state, sr.restaurant_zip_code, sr.category, sr.phone_number" +
                        "FROM saved_restaurants sr" +
                        "JOIN invite_restaurants ir ON ir.restaurant_id = sr.restaurant_id" +
                        "JOIN invites i ON i.invite_id = ir.invite_id" +
                        "JOIN user_invite ur ON ur.invite_id = ir.invite_id" +
                        "where ur.user_id = @userId", conn);
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
                InviteTitle = Convert.ToString(reader["i.invite_title"]),
                InviteId = Convert.ToInt32(reader["i.invite_id"]),
                ExpiryDate = Convert.ToDateTime(reader["expiry_date"]),
                EventDate = Convert.ToDateTime(reader["event_date"]),
                RestaurantId = Convert.ToInt32(reader["sr.restaurant_id"]),
                YelpRestaurantId = Convert.ToString(reader["sr.yelp_restaurant_id"]),
                RestaurantName = Convert.ToString(reader["sr.restaurant_name"]),
                RestaurantStreetAddress = Convert.ToString(reader["sr.restaurant_address"]),
                RestaurantCity = Convert.ToString(reader["sr.restaurant_city"]),
                RestaurantState = Convert.ToString(reader["sr.restaurant_state"]),
                RestaurantZip = Convert.ToString(reader["sr.restaurant_zip_code"]),
                Category = Convert.ToString(reader["sr.category"]),
                PhoneNumber = Convert.ToString(reader["sr.phone_number"]),
                PhotoUrl = Convert.ToString(reader["sr.photo_url"]),
            };

            return fullInvite;
        }
    }
}
