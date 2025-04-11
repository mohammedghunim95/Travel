using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class Countries
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Trip Type")]
        public string TripType { get; set; }

        public string Image { get; set; }

        public ICollection<Regions> Regions { get; set; }
        public ICollection<offers> offers { get; set; }
    }
}