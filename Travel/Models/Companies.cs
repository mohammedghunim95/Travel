using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class Companies
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }


        public ICollection<ApplicationUser> user { get; set; }
    }
}