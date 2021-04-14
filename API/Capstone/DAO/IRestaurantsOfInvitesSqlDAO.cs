using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRestaurantsOfInvitesSqlDAO
    {
        List<Invite> GetInvitesByUserId(int userId);
        List<RestaurantsOfInvites> GetInvitesByInviteId(int inviteId);
    }
}