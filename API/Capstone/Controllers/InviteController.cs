using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;

namespace Capstone.Controllers
{
    [Route("/invites")]
    [ApiController]
    public class InviteController : ControllerBase
    {
        private readonly IInviteDAO inviteDAO;

        public InviteController(IInviteDAO _inviteDAO)
        {
            inviteDAO = _inviteDAO;
        }

        [HttpGet("{inviteTitle}/invite")] //use id instead of name
        public ActionResult<Invite> GetInvite(string title)
        {
           Invite invite = inviteDAO.GetInviteByTitle(title);

            if (invite != null)
            {
                return invite;
            } else
            {
                return NotFound();
            }

            
        }

        [HttpPost("save")]
        public IActionResult SaveInvite(Invite inviteForm)
        {
            IActionResult result;

            Invite invite = inviteDAO.AddInvite(inviteForm.InviteId, inviteForm.InviteTitle, inviteForm.UserId, inviteForm.ExpiryDate, inviteForm.EventDate);
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
