using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EviromentalSurvey.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public int ContentId { get; set; }
        public virtual Content Content { get; set; }
    }
}