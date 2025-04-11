using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class ApplyForTrip
    {
        [Key]
        public int id { get; set; }
        public DateTime DateTime { get; set; }
        [Required]
        public string PersonNumber { get; set; }

        public string PricePersons { get; set; }

        [Display(Name = "Hiring Tour Guide")]
        public bool HiringTourGuide { get; set; }

        public int RegionId { get; set; }
        public string UserId { get; set; }
        public Regions Regions { get; set; }
        public ApplicationUser user { get; set; }
    }
}