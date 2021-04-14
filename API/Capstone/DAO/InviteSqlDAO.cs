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
        public List<Invite> GetInvitesByUserId(int userId)
        {
            List<Invite> listOfInvites = new List<Invite>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select invite_title FROM invites where user_id = @userId", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while(reader.HasRows && reader.Read())
                    {
                            listOfInvites.Add(GetInviteFromReader(reader));
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

                    SqlCommand cmd = new SqlCommand("SELECT invite_title, expiry_date, event_date FROM invites WHERE invite_id = @id", conn);
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
        public int AddInvite(string inviteTitle, int userId, DateTime expiryDate, DateTime eventDate)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            int identity = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO invites (invite_title, user_id, expiry_date, event_date) VALUES (@inviteTitle, @userid, @expiryDate, @eventDate); SELECT @@IDENTITY", conn);
                    cmd.Parameters.AddWithValue("@inviteTitle", inviteTitle);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@expiryDate", expiryDate.ToString(format));
                    cmd.Parameters.AddWithValue("@eventDate", eventDate.ToString(format));
                    identity = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return identity;
        }
        public int AddRestaurantToInvite(int userId, string inviteTitle, int restaurantId)
        {
            int identity = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO invite_restaurants(invite_id, restaurant_id)," +
                        "VALUES ((select invite_id from invites where user_id = @userId and invite_title = @inviteTitle), " +
                        "(select restaurant_id from saved_restaurants where restaurant_id = @restaurantId)); SELECT @@IDENTITY", conn);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@inviteTitle", inviteTitle);
                    cmd.Parameters.AddWithValue("@restaurantId", restaurantId);
                    identity = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return identity;
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
    }
}
