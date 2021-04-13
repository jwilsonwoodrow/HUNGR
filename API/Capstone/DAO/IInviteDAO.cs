using Capstone.Models;
using System;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IInviteDAO
    {
        int AddInvite(string inviteTitle, int userId, DateTime expiryDate, DateTime eventDate);
        int AddRestaurantToInvite(int userId, string inviteTitle, int restaurantId);
        Invite GetInviteById(int id);
        List<string> GetInvitesByUserId(int userId);
    }
}