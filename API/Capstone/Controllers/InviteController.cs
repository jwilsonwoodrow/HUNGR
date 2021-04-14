using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("/invites")]
    [ApiController]
    public class InviteController : AuthorizedControllerBase
    {
        private readonly IInviteDAO inviteDAO;
        private readonly IRestaurantDAO restaurantDAO;
        private readonly IUserDAO userDAO;
        private readonly IRestaurantsOfInvitesSqlDAO restInvitesDAO;

        public InviteController(IInviteDAO _inviteDAO, IRestaurantDAO _restaurantDAO, IUserDAO _userDAO, IRestaurantsOfInvitesSqlDAO _restInvitesDAO)
        {
            inviteDAO = _inviteDAO;
            restaurantDAO = _restaurantDAO;
            userDAO = _userDAO;
            restInvitesDAO = _restInvitesDAO;
        }

        [HttpGet("{inviteId}")]
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
        [HttpGet]
        [Authorize]
        public IActionResult GetInviteTitlesByUserId()
        {
            List<Invite> listOfInvites = restInvitesDAO.GetInvitesByUserId(this.UserId);

            return Ok(listOfInvites);
        }
        [HttpGet("{inviteId}")]
        [Authorize]
        public IActionResult GetInviteTitlesByUserId(int inviteId)
        {
            List<RestaurantsOfInvites> listOfInvites = restInvitesDAO.GetInvitesByInviteId(inviteId);

            return Ok(listOfInvites);
        }

        //[HttpGet]
        //[Authorize]
        //public IActionResult GetInviteDetailsByInviteId(int inviteId)
        //{
        //    Invite invite = inviteDAO.GetInviteById(inviteId);
        //    return Ok(invite);

        //}

        //Do we want to change this to GetRestaurantLikesDislikesByInviteId?
        //What to do about updating Likes and Dislikes?
        [HttpGet("{inviteId}/restaurants")]
        [Authorize]
        public IActionResult GetRestaurantsByInviteId(int inviteId)
        {
            List<InviteRestaurant> restaurants = restaurantDAO.GetRestaurantsByInviteId(inviteId);
            return Ok(restaurants);

        }

        [HttpPost("save")]
        [Authorize]
        public IActionResult SaveInvite(Invite inviteForm)
        {
            try
            {
                inviteForm.InviteId = inviteDAO.AddInvite(inviteForm.InviteTitle, this.UserId, inviteForm.ExpiryDate, inviteForm.EventDate);
                return Created("", inviteForm);
            }
            catch
            {
                return BadRequest(new { message = "An error occurred and the invite was not created." });
            }
        }

        [HttpPost("/restaurants")]
        [Authorize]
        public IActionResult SaveRestaurant(List<Restaurant> restaurants)
        {
            IActionResult result;

            List<int> identities = new List<int>();

            foreach(Restaurant restaurant in restaurants)
            {
                identities.Add(restaurantDAO.AddRestaurant(restaurant.YelpRestaurantId, restaurant.RestaurantName, restaurant.RestaurantStreetAddress, restaurant.RestaurantCity, restaurant.RestaurantState, restaurant.RestaurantZip, restaurant.Category, restaurant.PhoneNumber));
            }
            
            if (identities != null)
            {
                result = Ok(identities);
            }
            else
            {
                result = BadRequest(new { message = "An error occurred and the restaurant was not saved." });
            }

            return result;
        }
    }
}
