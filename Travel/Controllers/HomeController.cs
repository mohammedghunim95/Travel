using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public static string catid = "KH";

        public ActionResult Index()
        {
 
            return View(db.Regions.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Companies()
        {
            ViewData["cats"] = db.Regions;

            var region = db.Regions.Where(m => m.CompanyName == catid);
            return View(region);
        }

        public ActionResult Details(string category)
        {
            ViewData["cats"] = db.Regions;

            catid = category;

            var region = db.Regions.Where(m => m.CompanyName == catid);

            return View("Companies", region);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}