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

        public Restaurant GetRestaurantByName(string name)
        {
            Restaurant returnRestaurant = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT restaurant_id, yelp_restaurant_id, restaurant_name, restaurant_name, restaurant_address, restaurant_city, restaurant_state, restaurant_zip_code, category, phone_number FROM saved_restaurants WHERE restaurant_name = @name", conn);
                    cmd.Parameters.AddWithValue("@name", name);
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
        public List<Restaurant> GetCollectionByUserEmail(string email)
        {
            List<Restaurant> collection = new List<Restaurant>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT yelp_restaurant_id, restaurant_name, restaurant_address, restaurant_city, restaurant_state, restaurant_zip_code, category, phone_number FROM saved_restaurants sr JOIN user_restaurants ur ON ur.restaurant_id = sr.restaurant_id JOIN users u ON u.user_id = ur.user_id WHERE u.email = @email", conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        collection.Add(GetRestaurantFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return collection;
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
        public List<Restaurant> AddRestaurantToCollection(string email, string restaurantName)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO user_restaurants(user_id, restaurant_id) VALUES((select user_id from users where email = @email), (select restaurant_id from saved_restaurants where restaurant_name = @restaurantName));", conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@restaurantName", restaurantName);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetCollectionByUserEmail(email);
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
    }
}
