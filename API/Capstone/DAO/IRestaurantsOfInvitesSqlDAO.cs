using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRestaurantsOfInvitesSqlDAO
    {
        List<RestaurantsOfInvites> GetInvitesByUserId(int userId);
        List<RestaurantsOfInvites> GetInvitesByInviteId(int inviteId)
    }
}