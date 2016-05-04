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
        private BTBDatabase_1Entities2 db = new BTBDatabase_1Entities2();

        public ActionResult Index()
        {
            var HIModel = new HomeIndexModel();
            var DrinkShots = (from m in db.DrinkShots
                                 select m).ToList();
            //.IngredientList = (from m in db.Ingrediants
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
    }
}