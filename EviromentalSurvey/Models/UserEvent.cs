using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EviromentalSurvey.Models
{
    public class UserEvent
    {
        public int Id { get; set; }

        public DateTime DateOfJoining { get; set; }

        public string UserId { get; set; }

        public int EventId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Event Event { get; set; }
    }
}