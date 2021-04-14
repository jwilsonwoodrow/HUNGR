using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRestaurantFavoritesSqlDAO
    {
        List<RestaurantLikesDislikes> GetRestaurantLIkesDislikesByInviteId(int inviteId);
    }
}