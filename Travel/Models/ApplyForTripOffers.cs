using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Travel.Models
{
    public class ApplyForTripOffers
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string NumberPerson { get; set; }
        public int OfferId { get; set; }
        public string UserId { get; set; }

        public offers Offers { get; set; }

        public ApplicationUser user { get; set; }


    }
}