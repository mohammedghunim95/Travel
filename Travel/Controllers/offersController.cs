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
    public class offersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ApplyTripoffers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplyTripoffers(string numberperson)
        {
            var userid = User.Identity.GetUserId();
            var offerid = (int)Session["offerid"];

            var applyoffer = new ApplyForTripOffers();

            applyoffer.NumberPerson = numberperson;

            applyoffer.UserId = userid;
            applyoffer.OfferId = offerid;
            applyoffer.DateTime = DateTime.Now;

            db.ApplyForTripOffers.Add(applyoffer);
            db.SaveChanges();
            return RedirectToAction("Confirm","Regions");
        }

        [AllowAnonymous]
        public ActionResult AllOffers()
        {
            return View(db.offers.ToList());
        }

        [AllowAnonymous]
        public ActionResult List(int id)
        {
            return View(db.offers.Where(c => c.CountryId == id));
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            //.Where(a => a.UserID == userId)
            var offers = db.Regions.Include(o => o.Countries).Include(o => o.User);
            ////var region = db.Regions.Where(a => a.UserID == userId).Include(r => r.Countries);

            return View(offers.ToList());
        }

        // GET: offers/Details/5
        public ActionResult Details(int? id)
        {
            var offer = db.offers.Include(c => c.Countries).FirstOrDefault(c=>c.OfferId ==id);
            Session["offerid"] = id;
            return View(offer);
        }

        // GET: offers/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            return View();
        }

        // POST: offers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(offers offers, HttpPostedFileBase upload, HttpPostedFileBase uploadpdf, string mot)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                offers.Image = upload.FileName;

                string path2 = Path.Combine(Server.MapPath("~/files"), uploadpdf.FileName);
                uploadpdf.SaveAs(path2);
                offers.TouristProgram = uploadpdf.FileName;

                offers.MeanOfTransportation = mot;

                db.offers.Add(offers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", offers.CountryId);
            return View(offers);
        }

        // GET: offers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            offers offers = db.offers.Find(id);
            if (offers == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", offers.CountryId);
            return View(offers);
        }

        // POST: offers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(offers offers, HttpPostedFileBase upload, HttpPostedFileBase uploadpdf, string mot)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                offers.Image = upload.FileName;

                string path2 = Path.Combine(Server.MapPath("~/files"), uploadpdf.FileName);
                uploadpdf.SaveAs(path2);
                offers.TouristProgram = uploadpdf.FileName;

                offers.MeanOfTransportation = mot;

                db.Entry(offers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", offers.CountryId);
            return View(offers);
        }

        // GET: offers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            offers offers = db.offers.Find(id);
            if (offers == null)
            {
                return HttpNotFound();
            }
            return View(offers);
        }

        // POST: offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            offers offers = db.offers.Find(id);
            db.offers.Remove(offers);
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
