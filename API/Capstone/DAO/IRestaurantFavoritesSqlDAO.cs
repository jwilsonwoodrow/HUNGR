using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRestaurantFavoritesSqlDAO
    {
        List<RestaurantLikesDislikes> GetInvitesByInviteId(int inviteId);
        bool UpdateLikesByRestId(int restId, int numOfLikes);
        bool UpdateDislikesByRestId(int restId, int numOfDilikes);
        bool SaveRestaurantLikesDislikesByRestId(int restId, int numOfLikes, int numOfDislikes);
    }
}