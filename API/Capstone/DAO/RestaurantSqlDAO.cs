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

                    SqlCommand cmd = new SqlCommand("Select sr.photo_url, sr.restaurant_name, sr.restaurant_address, sr.restaurant_city, " +
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
        public int AddRestaurant(string photoUrl, string yelpId, string name, string address, string city, string state, string zip, string category, string phoneNum)
        {
            int identity = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select count(yelp_restaurant_id) from saved_restaurants where yelp_restaurant_id = @yelpId", conn);
                    cmd.Parameters.AddWithValue("@yelpId", yelpId);
                    int restCheck = Convert.ToInt32(cmd.ExecuteScalar());
                    Restaurant newRestaurant = this.GetRestaurantByYelpId(yelpId);

                    if (newRestaurant != null)
                    {
                        return newRestaurant.RestaurantId;
                    }
                    else
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO saved_restaurants (photo_url, yelp_restaurant_id, restaurant_name, restaurant_address, restaurant_city, restaurant_state, restaurant_zip_code, category, phone_number) VALUES (@photoUrl, @yelpId, @name, @address, @city, @state, @zip, @category, @phoneNum); select @@identity", conn);
                        cmd2.Parameters.AddWithValue("@photoUrl", photoUrl);
                        cmd2.Parameters.AddWithValue("@yelpId", yelpId);
                        cmd2.Parameters.AddWithValue("@name", name);
                        cmd2.Parameters.AddWithValue("@address", address);
                        cmd2.Parameters.AddWithValue("@city", city);
                        cmd2.Parameters.AddWithValue("@state", state);
                        cmd2.Parameters.AddWithValue("@zip", zip);
                        cmd2.Parameters.AddWithValue("@category", category);
                        cmd2.Parameters.AddWithValue("@phoneNum", phoneNum);
                        identity = Convert.ToInt32(cmd2.ExecuteScalar());
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return identity;
        }

        private Restaurant GetRestaurantFromReader(SqlDataReader reader)
        {
            Restaurant restaurant = new Restaurant()
            {
                RestaurantId = Convert.ToInt32(reader["restaurant_id"]),
                YelpRestaurantId = Convert.ToString(reader["yelp_restaurant_id"]),
                PhotoUrl = Convert.ToString(reader["photo_url"]),
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
                PhotoUrl = Convert.ToString(reader["sr.photo_url"]),
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
