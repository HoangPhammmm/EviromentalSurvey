using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EviromentalSurvey.Models
{
    public class Reward
    {
        public int Id { get; set; }

        public int Point { get; set; }

        [Required]
        [StringLength(50)]
        public string RewardName { get; set; }

        public int RewardContent { get; set; }

        public int ContentId { get; set; }

        public virtual Content Content { get; set; }
    }
}