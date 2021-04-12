using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class InviteSqlDAO
    {

        private readonly string connectionString;

        public InviteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Invite GetInviteByTitle(string title)
        {
            Invite returnInvite = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT invite_id, invite_title, user_id, expiry_date, event_date FROM invites WHERE invite_title = @title", conn);
                    cmd.Parameters.AddWithValue("@title", title);
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
        public Invite AddInvite(int inviteId, string inviteTitle, int userId, DateTime expiryDate, DateTime eventDate)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO invites (invite_id, invite_title, user_id, expiry_date, event_date) VALUES (@inviteId, @inviteTitle, @userId, @exiryDate, @eventDate)", conn);
                    cmd.Parameters.AddWithValue("@inviteId", inviteId);
                    cmd.Parameters.AddWithValue("@inviteTitle", inviteTitle);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@expiryDate", expiryDate);
                    cmd.Parameters.AddWithValue("@eventDate", eventDate);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return GetInviteByTitle(inviteTitle);
        }

        private Invite GetInviteFromReader(SqlDataReader reader)
        {
            Invite invite = new Invite()
            {
                InviteId = Convert.ToInt32(reader["invite_id"]),
                UserId = Convert.ToInt32(reader["yelp_restaurant_id"]),
                ExpiryDate = Convert.ToDateTime(reader["expiry_date"]),
                EventDate = Convert.ToDateTime(reader["event_date"]),
                InviteTitle = Convert.ToString(reader["invite_title"]),
            };

            return invite;
        }
    }
}
