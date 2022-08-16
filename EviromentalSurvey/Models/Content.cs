using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EviromentalSurvey.Models
{
    public class Content
    {
        public int Id { get; set; }

        public int CreateContentEventBy { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Sections { get; set; }

        [Required]
        [StringLength(255)]
        public string Detail { get; set; }
        [Required]
        public int EventId { get; set; }


        public int RewardId { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        [Required]
        public virtual Event Event { get; set; }

        public virtual Reward Reward { get; set; }

    }
}