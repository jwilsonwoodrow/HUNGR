using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class RestaurantSqlDAO : IRestaurantDAO
    {
        private readonly string connectionString;

        public RestaurantSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Restaurant GetRestaurantById(int id)
        {
            Restaurant returnRestaurant = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT restaurant_id, yelp_restaurant_id, restaurant_name, restaurant_name, restaurant_address, restaurant_city, restaurant_state, restaurant_zip_code, category, phone_number FROM saved_restaurants WHERE restaurant_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnRestaurant = GetRestaurantFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnRestaurant;
        }
        public List<InviteRestaurant> GetRestaurantsByInviteId(int inviteId)
        {
            List<InviteRestaurant> restaurants = new List<InviteRestaurant>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select sr.yelp_restaurant_id, sr.restaurant_name, sr.restaurant_address, sr.restaurant_city, " +
                        "sr.restaurant_state, sr.restaurant_zip_code, sr.category, sr.phone_number" +
                        "FROM saved_restaurants sr" +
                        "JOIN invite_restaurants ir ON ir.restaurant_id = sr.restaurant_id" +
                        "JOIN invites i ON i.invite_id = ir.invite_id" +
                        "where i.invite_id = @inviteId", conn);
                    cmd.Parameters.AddWithValue("@inviteId", inviteId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        restaurants.Add(GetInviteRestaurantFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return restaurants;
        }
        public Restaurant GetRestaurantByYelpId(string yelpId)
        {
            Restaurant returnRestaurant = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT restaurant_id, yelp_restaurant_id, restaurant_name, restaurant_address, restaurant_city, restaurant_state, restaurant_zip_code, category, phone_number FROM saved_restaurants WHERE yelp_restaurant_id = @yelpId", conn);
                    cmd.Parameters.AddWithValue("@yelpId", yelpId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnRestaurant = GetRestaurantFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnRestaurant;
        }
        public Restaurant AddRestaurant(string yelpId, string name, string address, string city, string state, string zip, string category, string phoneNum)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO saved_restaurants (yelp_restaurant_id, restaurant_name, restaurant_address, restaurant_city, restaurant_state, restaurant_zip_code, category, phone_number) VALUES (@yelpId, @name, @address, @city, @state, @zip, @category, @phoneNum)", conn);
                    cmd.Parameters.AddWithValue("@yelpId", yelpId);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@state", state);
                    cmd.Parameters.AddWithValue("@zip", zip);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@phoneNum", phoneNum);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetRestaurantByYelpId(yelpId);
        }

        private Restaurant GetRestaurantFromReader(SqlDataReader reader)
        {
            Restaurant restaurant = new Restaurant()
            {
                RestaurantId = Convert.ToInt32(reader["restaurant_id"]),
                YelpRestaurantId = Convert.ToString(reader["yelp_restaurant_id"]),
                RestaurantName = Convert.ToString(reader["restaurant_name"]),
                RestaurantStreetAddress = Convert.ToString(reader["restaurant_address"]),
                RestaurantCity = Convert.ToString(reader["restaurant_city"]),
                RestaurantState = Convert.ToString(reader["restaurant_state"]),
                RestaurantZip = Convert.ToString(reader["restaurant_zip_code"]),
                Category = Convert.ToString(reader["category"]),
                PhoneNumber = Convert.ToString(reader["phone_number"])
            };

            return restaurant;
        }

        private InviteRestaurant GetInviteRestaurantFromReader(SqlDataReader reader)
        {
            InviteRestaurant restaurantInvite = new InviteRestaurant()
            {
                YelpRestaurantId = Convert.ToString(reader["sr,yelp_restaurant_id"]),
                RestaurantName = Convert.ToString(reader["sr.restaurant_name"]),
                RestaurantStreetAddress = Convert.ToString(reader["sr.restaurant_address"]),
                RestaurantCity = Convert.ToString(reader["sr.restaurant_city"]),
                RestaurantState = Convert.ToString(reader["sr.restaurant_state"]),
                RestaurantZip = Convert.ToString(reader["sr.restaurant_zip_code"]),
                Category = Convert.ToString(reader["sr.category"]),
                PhoneNumber = Convert.ToString(reader["sr.phone_number"])
            };

            return restaurantInvite;
        }
    }
}
