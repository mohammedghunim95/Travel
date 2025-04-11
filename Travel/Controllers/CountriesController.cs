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
    public class CountriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Countries
        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }

        [AllowAnonymous]
        public ActionResult AllCountries()
        {
            return View(db.Countries.ToList());
        }

        // GET: Countries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Countries countries = db.Countries.Find(id);
            if (countries == null)
            {
                return HttpNotFound();
            }
            return View(countries);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Countries countries, string TripType, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                countries.Image = upload.FileName;

                countries.TripType = TripType;

                db.Countries.Add(countries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countries);
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Countries countries = db.Countries.Find(id);
            if (countries == null)
            {
                return HttpNotFound();
            }
            return View(countries);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Countries countries, string TripType, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                countries.Image = upload.FileName;

                countries.TripType = TripType;

                db.Entry(countries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countries);
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Countries countries = db.Countries.Find(id);
            if (countries == null)
            {
                return HttpNotFound();
            }
            return View(countries);
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Countries countries = db.Countries.Find(id);
            db.Countries.Remove(countries);
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
