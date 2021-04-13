namespace Capstone.DAO
{
    public interface IGenerateInviteDAO
    {
        int AddInviteIdToRestaurantId(int inviteId, int restaurantId);
    }
}