using Capstone.Models;
using System;

namespace Capstone.DAO
{
    public interface IInviteDAO
    {
        Invite AddInvite(int inviteId, string inviteTitle, int userId, DateTime expiryDate, DateTime eventDate);
        Invite GetInviteByTitle(string title);
    }
}