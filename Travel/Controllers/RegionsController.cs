using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel.Models;

namespace Travel.Controllers
{
    [Authorize]
    public class RegionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Confirm()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult List(int id)
        {
            return View(db.Regions.Where(c => c.CountryId == id));
        }

        [AllowAnonymous]
        public ActionResult RegionDetails(int id)
        {
            //regions = db.Regions.Find(id);
            var regions = db.Regions.Include(c => c.Countries).FirstOrDefault(r => r.RegionId == id);
            Session["regionid"] = id;
            return View(regions);
        }

        public ActionResult ApplyTrip()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplyTrip(string PersonNumber, bool Hiring)
        {
            var userId = User.Identity.GetUserId();
            var regionId = (int)Session["regionid"];

            var check = db.applyForTrips.Where(a => a.RegionId == regionId && a.UserId == userId);

            if (check.Count()<1 )
            {

                var apply = new ApplyForTrip();


                apply.UserId = userId;
                apply.RegionId = regionId;
                apply.PersonNumber = PersonNumber;
                apply.HiringTourGuide = Hiring;
                apply.DateTime = DateTime.Now;

                db.applyForTrips.Add(apply);
                db.SaveChanges();

                return RedirectToAction("Confirm");
            }
            else
            {
                ViewBag.message = "I have already booked this trip";
            }
            return View();

        }

        [Authorize]
        public ActionResult GetTripByUser()
        {
            var userId = User.Identity.GetUserId();
            var regions = db.applyForTrips.Where(a => a.UserId == userId);

            return View(regions.ToList());
        }

        [Authorize]
        public ActionResult TourismCompany()
        {
            //var UserId = User.Identity.GetUserId();

            //var region = from app in db.applyForTrips
            //             join reg in db.Regions
            //             on app.id equals reg.RegionId
            //             where reg.User.Id == UserId
            //             select app;

            var userId = User.Identity.GetUserId();
            //var regionid = (int)Session["regionid"];

            // var regions = db.applyForTrips.Where(a => a.UserId == userId);

            var regions = db.applyForTrips.Include(c => c.Regions).Include(c=>c.user).Where(a => a.UserId == userId).ToList();
            //var regions = db.applyForTrips.Where(a => a.UserId == userId);
            //var rg =  regions;

            return View(regions.ToList());

            //return View(region.ToList());
        }


        // GET: Regions
        //public ActionResult Index()
        //{
        //    var regions = db.Regions.Include(r => r.Countries);
        //    return View(regions.ToList());
        //}

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var region = db.Regions.Where(a=>a.UserID ==userId).Include(r=>r.Countries);
            return View(region.ToList());
        }

        // GET: Regions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regions regions = db.Regions.Find(id);
            if (regions == null)
            {
                return HttpNotFound();
            }
            return View(regions);
        }

        // GET: Regions/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Regions regions,HttpPostedFileBase upload , HttpPostedFileBase uploadpdf, string mot)//, HttpPostedFileBase uploadVideo
        {
            if (ModelState.IsValid)
            {
                //var path = "";
                //foreach(var item in upload)
                //{
                //    if(item != null)
                //    {
                //        if (item.ContentLength > 0)
                //        {
                //            if(Path.GetExtension(item.FileName).ToLower()== ".jpg"
                //                || Path.GetExtension(item.FileName).ToLower()==".png"
                //                || Path.GetExtension(item.FileName).ToLower()=="jpeg")
                //            {
                //                   path = Path.Combine(Server.MapPath("~/images"), item.FileName);
                //                   item.SaveAs(path);
                //                   regions.Image = item.FileName;

                //            }
                //        }
                //    }
                //}

                    string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                    upload.SaveAs(path);
                    regions.Image = upload.FileName;

                string path2 = Path.Combine(Server.MapPath("~/files"), uploadpdf.FileName);
                uploadpdf.SaveAs(path2);
                regions.TouristProgram = uploadpdf.FileName;

                //string path3 = Path.Combine(Server.MapPath("~/Videos"), uploadVideo.FileName);
                //uploadVideo.SaveAs(path);
                //regions.Video = uploadVideo.FileName;

                regions.MeanOfTransportation = mot;
                regions.UserID = User.Identity.GetUserId();
                db.Regions.Add(regions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", regions.CountryId);
            return View(regions);
        }

        // GET: Regions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regions regions = db.Regions.Find(id);
            if (regions == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", regions.CountryId);
            return View(regions);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Regions regions,string mot, HttpPostedFileBase upload, HttpPostedFileBase uploadpdf)//, HttpPostedFileBase uploadVideo
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                regions.Image = upload.FileName;

                string path2 = Path.Combine(Server.MapPath("~/files"), uploadpdf.FileName);
                uploadpdf.SaveAs(path2);
                regions.TouristProgram = uploadpdf.FileName;


                //string path3 = Path.Combine(Server.MapPath("~/Videos"), uploadVideo.FileName);
                //uploadVideo.SaveAs(path);
                //regions.Video = uploadVideo.FileName;

                regions.MeanOfTransportation = mot;

                db.Entry(regions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", regions.CountryId);
            return View(regions);
        }

        // GET: Regions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regions regions = db.Regions.Find(id);
            if (regions == null)
            {
                return HttpNotFound();
            }
            return View(regions);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Regions regions = db.Regions.Find(id);
            db.Regions.Remove(regions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
