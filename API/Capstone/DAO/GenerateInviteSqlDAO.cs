using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class GenerateInviteSqlDAO : IGenerateInviteDAO
    {

        private readonly string connectionString;

        public GenerateInviteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddInviteIdToRestaurantId(int inviteId, int restaurantId)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO invite_restaurants(invite_id, restaurant_id)" +
                        "VALUES(@inviteId, @restaurantId); SELECT @@IDENTITY", conn);
                    cmd.Parameters.AddWithValue("@inviteId", inviteId);
                    cmd.Parameters.AddWithValue("@restaurantId", restaurantId);
                    rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;

                    }
                    else return false;
                }
            }
            catch (SqlException)
            {
                throw;
            }
                if (rowsAffected > 0)
                {
                    return true;

                }
                else return false;
        }

        private InviteIdRestaurantId GetInviteIdRestaurantIdFromReader(SqlDataReader reader)
        {
            InviteIdRestaurantId invite = new InviteIdRestaurantId()
            {
                InviteId = Convert.ToInt32(reader["invite_id"]),
                RestaurantId = Convert.ToInt32(reader["restaurant_id"]),
            };

            return invite;
        }
    }
}
