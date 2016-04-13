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
    public class IngredientsController : Controller
    {
        private BTBDatabase_1Entities2 db = new BTBDatabase_1Entities2();

        // GET: Ingredients
        public ActionResult Index()
        {
            var ingrediants = db.Ingrediants.Include(i => i.User);
            return View(ingrediants.ToList());
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediant ingrediant = db.Ingrediants.Find(id);
            if (ingrediant == null)
            {
                return HttpNotFound();
            }
            return View(ingrediant);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email");
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Image,SubmittedBy,CostLiter,Date,Type")] Ingrediant ingrediant)
        {
            if (ModelState.IsValid)
            {
                db.Ingrediants.Add(ingrediant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email", ingrediant.SubmittedBy);
            return View(ingrediant);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediant ingrediant = db.Ingrediants.Find(id);
            if (ingrediant == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email", ingrediant.SubmittedBy);
            return View(ingrediant);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Description,Image,SubmittedBy,CostLiter,Date,Type")] Ingrediant ingrediant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingrediant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email", ingrediant.SubmittedBy);
            return View(ingrediant);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingrediant ingrediant = db.Ingrediants.Find(id);
            if (ingrediant == null)
            {
                return HttpNotFound();
            }
            return View(ingrediant);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ingrediant ingrediant = db.Ingrediants.Find(id);
            db.Ingrediants.Remove(ingrediant);
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
