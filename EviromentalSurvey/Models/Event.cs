using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EviromentalSurvey.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public int ConfirmBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDay { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDay { get; set; }

        [StringLength(255)]
        public string Status { get; set; }
        [Required]
        public int ContentId { get; set; }

        public virtual ICollection<UserEvent> UserEvents { get; set; }

        public virtual ICollection<FAQ> FAQs { get; set; }
        [Required]
        public virtual Content Content { get; set; }
    }
}