using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("/invites")]
    [ApiController]
    public class InviteController : AuthorizedControllerBase
    {
        private readonly IInviteDAO inviteDAO;
        private readonly IRestaurantDAO restaurantDAO;
        private readonly IUserDAO userDAO;

        public InviteController(IInviteDAO _inviteDAO, IRestaurantDAO _restaurantDAO, IUserDAO _userDAO)
        {
            inviteDAO = _inviteDAO;
            restaurantDAO = _restaurantDAO;
            userDAO = _userDAO;
        }

        [HttpGet("/invite/{inviteId}")] //use id instead of name 
        //Maybe also need to add user id???
        public ActionResult<Invite> GetInvite(int inviteId)
        {
           Invite invite = inviteDAO.GetInviteById(inviteId);

            if (invite != null)
            {
                return invite;
            } else
            {
                return NotFound();
            }

            
        }

        [HttpPost("save")]
        [Authorize]
        public IActionResult SaveInvite(Invite inviteForm)
        {
            IActionResult result;

            Invite invite = inviteDAO.AddInvite(inviteForm.InviteTitle, this.UserId, inviteForm.ExpiryDate, inviteForm.EventDate);
            if (invite != null)
            {
                result = Created(invite.InviteTitle, null);
            }
            else
            {
                result = BadRequest(new { message = "An error occurred and the invite was not created." });
            }

            return result;
        }
    }
}
