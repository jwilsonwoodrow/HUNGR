using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRestaurantFavoritesSqlDAO
    {
        List<RestaurantLikesDislikes> GetInvitesByInviteId(int inviteId);
        bool UpdateLikesDislikesByRestId(int restId, int numOfLikes, int numOfDislikes);
    }
}