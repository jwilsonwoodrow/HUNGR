using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;

namespace Capstone.Controllers
{
    [Route("/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IInviteDAO inviteDAO; //invites + user_invites
        private readonly IRestaurantDAO restaurantDAO;
        private readonly IUserDAO userDAO;

        public EventController(IInviteDAO _inviteDAO)
        {
            inviteDAO = _inviteDAO;
        }
    }
}
