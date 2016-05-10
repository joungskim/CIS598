using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CIS598PROJECT.Models
{
    public class UserRatingsController : Controller
    {
        private BTBDatabaseEntities2 db = new BTBDatabaseEntities2();

        // GET: UserRatings
        public ActionResult Index()
        {
            return View(db.UserRatings.ToList());
        }

        // GET: UserRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = db.UserRatings.Find(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            return View(userRating);
        }

        // GET: UserRatings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DSName,SubmittedBy,Rating,Description,Date,Show")] UserRating userRating)
        {
            if (ModelState.IsValid)
            {
                db.UserRatings.Add(userRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userRating);
        }

        // GET: UserRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = db.UserRatings.Find(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            return View(userRating);
        }

        // POST: UserRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DSName,SubmittedBy,Rating,Description,Date,Show")] UserRating userRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userRating);
        }

        // GET: UserRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserRating userRating = db.UserRatings.Find(id);
            if (userRating == null)
            {
                return HttpNotFound();
            }
            return View(userRating);
        }

        // POST: UserRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRating userRating = db.UserRatings.Find(id);
            db.UserRatings.Remove(userRating);
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
