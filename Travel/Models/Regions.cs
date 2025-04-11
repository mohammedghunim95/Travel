using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Travel.Models
{
    public class Regions
    {
        [Key]
        public int RegionId { get; set; }

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
        [Display(Name = "Things To Do")]
        [AllowHtml]
        public string ThingsToDo { get; set; }

        [Required]
        [Display(Name = "Corona Status")]
        [AllowHtml]
        public string CoronaStatus { get; set; }

        [Required]
        public string CompanyName { get; set; }  

        [Required]
        [Display(Name = "Corona Description")]
        [AllowHtml]
        public string CoronaDescription { get; set; }

        public string Video { get; set; }

        public string UserID { get; set; }

        [Display(Name ="Country")]
        public int CountryId { get; set; }
        public Countries Countries { get; set; }

        public ApplicationUser User { get; set; }
    }
}