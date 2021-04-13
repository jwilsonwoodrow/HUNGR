namespace Capstone.DAO
{
    public interface IGenerateInviteDAO
    {
        bool AddInviteIdToRestaurantId(int inviteId, int restaurantId);
    }
}