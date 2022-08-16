using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EviromentalSurvey.Models
{
    public class FAQ
    {
        public int Id { get; set; }

        public int FQAEventBy { get; set; }

        [StringLength(255)]
        public string Question { get; set; }

        [StringLength(255)]
        public string Answer { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}