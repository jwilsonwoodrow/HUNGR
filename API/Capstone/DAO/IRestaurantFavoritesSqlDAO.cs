using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO
{
    public interface IRestaurantFavoritesSqlDAO
    {
        List<RestaurantLikesDislikes> GetInvitesByInviteId(int inviteId);
        bool AddLike(int restId);
        bool AddDislike(int restId);
        bool SaveRestaurantLikesDislikesByRestId(int restId, int numOfLikes, int numOfDislikes);
    }
}