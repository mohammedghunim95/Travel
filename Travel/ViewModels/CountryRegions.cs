using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel.Models;

namespace Travel.ViewModels
{
    public class CountryRegions
    {
        public Countries Countries { get; set; }
        public Regions Regions { get; set; }
    }
}