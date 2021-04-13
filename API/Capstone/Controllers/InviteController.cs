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

        //[HttpPost("/generateInvite")]
        //[Authorize]
        //public IActionResult GenerateInvite()
        //{
        //    IActionResult result;

        //    Restaurant newRestaurant = restaurantDAO.AddRestaurant(restaurant.YelpRestaurantId, restaurant.RestaurantName, restaurant.RestaurantStreetAddress, restaurant.RestaurantCity, restaurant.RestaurantState, restaurant.RestaurantZip, restaurant.Category, restaurant.PhoneNumber);
        //    if (newRestaurant != null)
        //    {
        //        result = Created(newRestaurant.RestaurantName, null);
        //    }
        //    else
        //    {
        //        result = BadRequest(new { message = "An error occurred and the restaurant was not saved." });
        //    }

        //    return result;
        //}
    }
}
