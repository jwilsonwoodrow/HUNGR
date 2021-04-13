using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class InviteSqlDAO : IInviteDAO
    {

        private readonly string connectionString;

        public InviteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<UserInvite> GetInvitesByUserId(int userId)
        {
            List<UserInvite> listOfInvites = new List<UserInvite>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select i.invite_title, sr.yelp_restaurant_id, sr.restaurant_name, sr.restaurant_address, sr.restaurant_city, " +
                        "sr.restaurant_state, sr.restaurant_zip_code, sr.category, sr.phone_number" +
                        "FROM saved_restaurants sr" +
                        "JOIN invite_restaurants ir ON ir.restaurant_id = sr.restaurant_id" +
                        "JOIN invites i ON i.invite_id = ir.invite_id" +
                        "JOIN user_invite ur ON ur.invite_id = ir.invite_id" +
                        "where ur.user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        listOfInvites.Add(GetUserInviteFromReader(reader));
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return listOfInvites;
        }
        public Invite GetInviteById(int id)
        {
            Invite returnInvite = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT invite_id, invite_title, expiry_date, event_date FROM invites WHERE invite_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnInvite = GetInviteFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnInvite;
        }
        public Invite AddInvite(string inviteTitle, int userId, DateTime expiryDate, DateTime eventDate)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO invites (invite_title, user_id, expiry_date, event_date) VALUES (@inviteTitle, @userid, @expiryDate, @eventDate)", conn);
                    cmd.Parameters.AddWithValue("@inviteTitle", inviteTitle);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@expiryDate", expiryDate.ToString(format));
                    cmd.Parameters.AddWithValue("@eventDate", eventDate.ToString(format));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetInviteById(inviteId);
        }
        public List<UserInvite> AddRestaurantToInvite(int userId, string inviteTitle, int restaurantId)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO invite_restaurants(invite_id, restaurant_id)," +
                        "VALUES ((select invite_id from invites where user_id = @userId and invite_title = @inviteTitle), " +
                        "(select restaurant_id from saved_restaurants where restaurant_id = @restaurantId));", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@inviteTitle", inviteTitle);
                    cmd.Parameters.AddWithValue("@restaurantId", restaurantId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetInvitesByUserId(userId);
        }

        private Invite GetInviteFromReader(SqlDataReader reader)
        {
            Invite invite = new Invite()
            {
                InviteId = Convert.ToInt32(reader["invite_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
                ExpiryDate = Convert.ToDateTime(reader["expiry_date"]),
                EventDate = Convert.ToDateTime(reader["event_date"]),
                InviteTitle = Convert.ToString(reader["invite_title"]),
            };

            return invite;
        }
        private UserInvite GetUserInviteFromReader(SqlDataReader reader)
        {
            UserInvite userInvite = new UserInvite()
            {
                InviteTitle = Convert.ToString(reader["i.invite_title"]),
                YelpRestaurantId = Convert.ToString(reader["sr,yelp_restaurant_id"]),
                RestaurantName = Convert.ToString(reader["sr.restaurant_name"]),
                RestaurantStreetAddress = Convert.ToString(reader["sr.restaurant_address"]),
                RestaurantCity = Convert.ToString(reader["sr.restaurant_city"]),
                RestaurantState = Convert.ToString(reader["sr.restaurant_state"]),
                RestaurantZip = Convert.ToString(reader["sr.restaurant_zip_code"]),
                Category = Convert.ToString(reader["sr.category"]),
                PhoneNumber = Convert.ToString(reader["sr.phone_number"])
            };

            return userInvite;
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
