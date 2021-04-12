using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Invite
    {
        public int InviteId { get; set; }
        public string InviteTitle { get; set; }
        public int UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime EventDate { get; set; }

    }

    public class InviteAttendees
    {
        public int InviteId { get; set; }
        public int AttendeeId { get; set; }
    }
    public class InviteRestaurants
    {
        public int InviteId { get; set; }
        public int RestaurantId { get; set; }
    }
}
