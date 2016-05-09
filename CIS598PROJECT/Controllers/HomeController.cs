using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CIS598PROJECT.Models;
using System.Data;
using System.Data.Entity;

namespace CIS598PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private BTBDatabaseEntities2 db = new BTBDatabaseEntities2();

        public ActionResult Index()
        {
            var HIModel = new HomeIndexModel();
            var DrinkShots = (from m in db.DrinkShots
                                 where m.Show != false
                                 select m).ToList();
            //.IngredientList = (from m in db.Ingredients
            //                        orderby m.Name
            //                        select m).ToList();
            return View(DrinkShots);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Index(string id)
        {
            ViewBag.Message = "Search Results";
            var drinkSearch = new List<DrinkShot>();
            return View();
        }

        public ActionResult Chat()
        {
            return View("_chat");
        }
    }
}