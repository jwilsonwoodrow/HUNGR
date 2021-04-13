using Capstone.Models;
using System;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IInviteDAO
    {
        Invite AddInvite(string inviteTitle, int userId, DateTime expiryDate, DateTime eventDate);
        List<UserInvite> AddRestaurantToInvite(int userId, string inviteTitle, int restaurantId);
        Invite GetInviteById(int id);
        List<UserInvite> GetInvitesByUserId(int userId);
    }
}