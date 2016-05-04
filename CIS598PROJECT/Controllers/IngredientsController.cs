using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CIS598PROJECT.Models;

namespace CIS598PROJECT.Models
{
    public class IngredientsController : Controller
    {
        private BTBDatabaseEntities2 db = new BTBDatabaseEntities2();
        //private string identity = 
        // GET: Ingredients
        public ActionResult Index()
        {

            var Ingredients = db.Ingredients.Include(i => i.User);
            Ingredients = Ingredients.Where(m => m.Show != false);
            return View(Ingredients.ToList());
        }

        public byte[] GetImageFromDataBase(string name)
        {
            byte[] cover = null;
            var q = from temp in db.Ingredients where temp.Name.Equals(name) select temp.Image;
            try
            {
                cover = q.First();
            }
            catch
            {

            }
            return cover;
        }
        /// <summary>
        /// Search for Ingredients index
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string id)
        {
            var ingredients = from m in db.Ingredients
                              where m.Show != false
                              select m;

            if (!String.IsNullOrEmpty(id))
            {
                ingredients = ingredients.Where(s => s.Name.Contains(id) ||
                                                s.Type.Contains(id) ||
                                                s.SubmittedBy.Contains(id) ||
                                                s.Description.Contains(id) ||
                                                s.Show != false);

            }

            return View(ingredients);
        }


        // GET: Ingredients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient Ingredient = db.Ingredients.Find(id);
            if (Ingredient == null || Ingredient.Show==false)
            {
                return HttpNotFound();
            }
            return View(Ingredient);
        }

        // GET: Ingredients/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,Image,SubmittedBy,CostLiter,Date,Type")] Ingredient Ingredient)
        {
            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email");
            HttpPostedFileBase file = Request.Files["ImageData"];
            BTBDatabaseEntities2 service = new BTBDatabaseEntities2();
            Ingredient.Date = DateTime.UtcNow;
            db = new BTBDatabaseEntities2();
            Ingredient.Image = new Controllers.ConversionController().ConvertToBytes(file);
            
            if (ModelState.IsValid)
            {
                db.Ingredients.Add(Ingredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email", Ingredient.SubmittedBy);
            return View(Ingredient);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient Ingredient = db.Ingredients.Find(id);
            if (Ingredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email", Ingredient.SubmittedBy);
            return View(Ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Description,Image,SubmittedBy,CostLiter,Date,Type")] Ingredient Ingredient)
        {
            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email");
            HttpPostedFileBase file = Request.Files["ImageData"];
            BTBDatabaseEntities2 service = new BTBDatabaseEntities2();
            Ingredient.Date = DateTime.UtcNow;
            db = new BTBDatabaseEntities2();
            Ingredient.Image = new Controllers.ConversionController().ConvertToBytes(file);

            if (ModelState.IsValid)
            {
                db.Entry(Ingredient).State = EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email", Ingredient.SubmittedBy);
            return View(Ingredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient Ingredient = db.Ingredients.Find(id);
            if (Ingredient == null || Ingredient.Show == false)
            {
                return HttpNotFound();
            }
            return View(Ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Ingredient Ingredient = db.Ingredients.Find(id);
            Ingredient.Show = false;
            db.Entry(Ingredient).State = EntityState.Modified; 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Retrieve an image from a databases
        [HttpGet]
        public ActionResult RetrieveImage(string id)
        {
            byte[] cover = GetImageFromDataBase(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
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
