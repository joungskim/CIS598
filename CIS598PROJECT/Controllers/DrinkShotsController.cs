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
    public class DrinkShotsController : Controller
    {
        private BTBDatabaseEntities2 db = new BTBDatabaseEntities2();

        // GET: DrinkShots
        public ActionResult Index()
        {
            var drinkShots = db.DrinkShots.Include(d => d.User);
            drinkShots = drinkShots.Where(d => d.Show != false);
            return View(drinkShots.ToList());
        }
        [HttpPost]
        public ActionResult Index(string id)
        {
            var drinkshots = from m in db.DrinkShots
                              where m.Show !=false
                              select m;
            var ingredients = from m in db.IngredientRecipes
                              where m.Show != false
                              select m;

            if (!String.IsNullOrEmpty(id))
            {
                drinkshots = drinkshots.Where(s => s.Name.Contains(id) ||
                                                s.Type.Contains(id) ||
                                                s.SubmittedBy.Contains(id));
            }

            return View(drinkshots);
        }
        // GET: DrinkShots/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkShot drinkShot = db.DrinkShots.Find(id);
            if (drinkShot == null || drinkShot.Show == false)
            {
                return HttpNotFound();
            }
            return View(drinkShot);
        }

        // GET: DrinkShots/Create
        public ActionResult Create()
        {
            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email");
            var model = new DSCreateModel();
            model.IngredientList = (from m in db.Ingredients
                                    where m.Show != false
                                    orderby m.Name
                                    select m).ToList();
            return View(model);
        }

        // POST: DrinkShots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DSCreateModel DSCreate)
        //public ActionResult Create([Bind(Include = "Name,SubmittedBy,Instructions,RatingTotal,ViewCount,Image,Cost,Date,Type")] DrinkShot drinkShot)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            BTBDatabaseEntities2 service = new BTBDatabaseEntities2();
            db = new BTBDatabaseEntities2();
            DSCreate.Drinkshot.Image = new Controllers.ConversionController().ConvertToBytes(file);
            DSCreate.Drinkshot.Cost = System.Convert.ToDecimal(CalculateCost(DSCreate.SelectedIngredients).ToString("#.##"));
            DSCreate.Drinkshot.RatingTotal = 0;
            DSCreate.Drinkshot.ViewCount = 0;
            DSCreate.Drinkshot.Date = DateTime.UtcNow;
            
            for (int i = 0; i < DSCreate.SelectedIngredients.Count(); i++)
            {
                
                DSCreate.Recipe = new IngredientRecipe();
                DSCreate.Recipe.DSName = DSCreate.Drinkshot.Name;
                DSCreate.Recipe.IngredientName = DSCreate.SelectedIngredients[i];
                DSCreate.Recipe.Ounces = 0;
                DSCreate.Recipe.Id = 1 + i + db.IngredientRecipes.Count();
                db.IngredientRecipes.Add(DSCreate.Recipe);
            }
            db.DrinkShots.Add(DSCreate.Drinkshot);
            if (ModelState.IsValid)
            {
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            DSCreate.IngredientList = (from m in db.Ingredients
                                    orderby m.Name
                                    select m).ToList();
            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email", DSCreate.Drinkshot);
            return View(DSCreate);
        }

        // GET: DrinkShots/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkShot drinkShot = db.DrinkShots.Find(id);
            if (drinkShot == null || drinkShot.Show==false)
            {
                return HttpNotFound();
            }
            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email", drinkShot.SubmittedBy);
            return View(drinkShot);
        }

        // POST: DrinkShots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,SubmittedBy,Instructions,RatingTotal,ViewCount,Image,Cost,Date,Type")] DrinkShot drinkShot)
        {
            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email");
            HttpPostedFileBase file = Request.Files["ImageData"];
            BTBDatabaseEntities2 service = new BTBDatabaseEntities2();
            drinkShot.Date = DateTime.UtcNow;
            db = new BTBDatabaseEntities2();
            drinkShot.Image = new Controllers.ConversionController().ConvertToBytes(file);

            if (ModelState.IsValid)
            {
                db.Entry(drinkShot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubmittedBy = new SelectList(db.Users, "User1", "Email", drinkShot.SubmittedBy);
            return View(drinkShot);
        }

        // GET: DrinkShots/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrinkShot drinkShot = db.DrinkShots.Find(id);
            if (drinkShot == null || drinkShot.Show == false)
            {
                return HttpNotFound();
            }
            return View(drinkShot);
        }

        // POST: DrinkShots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DrinkShot drinkShot = db.DrinkShots.Find(id);
            drinkShot.Show = false;
            db.Entry(drinkShot).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        /// <summary>
        /// Calculates the cost for drinks.
        /// </summary>
        /// <param name="Ingredients"></param>
        /// <returns></returns>
        public decimal CalculateCost(string[] Ingredients)
        {
            
            decimal cost = 0;
            for (int i = 0; i < Ingredients.Count(); i++)
            {
                decimal temp = 0;
                var c = db.Ingredients.Find(Ingredients[i]);
                if (c.CostLiter.HasValue) temp = c.CostLiter.Value;
                temp = decimal.Divide((temp * System.Convert.ToDecimal(1.25)), System.Convert.ToDecimal(33.81 * Ingredients.Count()));
                cost += temp;
            }
            return cost;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
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

        public byte[] GetImageFromDataBase(string name)
        {
            byte[] cover = null;
            var q = from temp in db.DrinkShots where temp.Name.Equals(name) select temp.Image;
            try
            {
                cover = q.First();
            }
            catch
            {

            }
            return cover;
        }




    }
}
