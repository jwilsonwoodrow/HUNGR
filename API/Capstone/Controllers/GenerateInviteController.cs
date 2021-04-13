using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("/invite")]
    [ApiController]
    public class GenerateInviteController : AuthorizedControllerBase
    {
        private readonly IGenerateInviteDAO generateInviteDAO;

        public GenerateInviteController(IGenerateInviteDAO _generateInviteDAO)
        {
            generateInviteDAO = _generateInviteDAO;
        }

        [HttpPost("{inviteId}/restaurants")]
        [Authorize]
        public IActionResult GenerateInvite(int inviteId, List<int> restaurantIds)
        {
            foreach(int restId in restaurantIds)
            {
                generateInviteDAO.AddInviteIdToRestaurantId(inviteId, restId);
                
            }
            return Ok();
        }
    }
}
