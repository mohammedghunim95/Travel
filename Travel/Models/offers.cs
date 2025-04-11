using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models
{
    public class offers
    {
        [Key]
        public int OfferId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        public string Image { get; set; }

        [Display(Name = "Tourist Program")]
        public string TouristProgram { get; set; }

        [Display(Name = "Mean Of Transportation")]
        public string MeanOfTransportation { get; set; }


        [Required]
        [AllowHtml]
        [Display(Name="Things To Do")]
        public string ThingsToDo { get; set; }

        public string UserID { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public Countries Countries { get; set; }

        public ApplicationUser User { get; set; }
    }
}