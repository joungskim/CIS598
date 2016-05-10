﻿using System;
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
using CIS598PROJECT.Controllers;

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

        [HttpPost]
        public ActionResult Search(string id)
        {
            var drinkshots = from m in db.DrinkShots
                             where m.Show != false
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

        public ActionResult Chat()
        {
            return View("_chat");
        }
        public ActionResult ChatLog()
        {
            var mb = db.MessageBoards.Where(t=>t.Show != false);
            return View(mb);
        }
        //public JsonResult SendRating(string r, string s, string id, string url)
        //{
        //    int autoId = 0;
        //    Int16 thisVote = 0;
        //    Int16 sectionId = 0;
        //    Int16.TryParse(s, out sectionId);
        //    Int16.TryParse(r, out thisVote);
        //    int.TryParse(id, out autoId);

        //    if (!User.Identity.IsAuthenticated)
        //    {
        //        return Json("Not authenticated!");
        //    }

        //    if (autoId.Equals(0))
        //    {
        //        return Json("Sorry, record to vote doesn't exists");
        //    }

        //    switch (s)
        //    {
        //        case "5": // school voting
        //            // check if he has already voted
        //            var isIt = db.UserRatings.Where(v => v.DSName == sectionId.ToString() &&
        //                v.SubmittedBy.Equals(User.Identity.Name, StringComparison.CurrentCultureIgnoreCase) && v.VoteForId == autoId).FirstOrDefault();
        //            if (isIt != null)
        //            {
        //                // keep the school voting flag to stop voting by this member
        //                HttpCookie cookie = new HttpCookie(url, "true");
        //                Response.Cookies.Add(cookie);
        //                return Json("<br />You have already rated this post, thanks !");
        //            }

        //            var sch = db.UserRatings.Where(sc => sc.ID == autoId).FirstOrDefault();
        //            if (sch != null)
        //            {
        //                object obj = sch.Votes;

        //                string updatedVotes = string.Empty;
        //                string[] votes = null;
        //                if (obj != null && obj.ToString().Length > 0)
        //                {
        //                    string currentVotes = obj.ToString(); // votes pattern will be 0,0,0,0,0
        //                    votes = currentVotes.Split(',');
        //                    // if proper vote data is there in the database
        //                    if (votes.Length.Equals(5))
        //                    {
        //                        // get the current number of vote count of the selected vote, always say -1 than the current vote in the array 
        //                        int currentNumberOfVote = int.Parse(votes[thisVote - 1]);
        //                        // increase 1 for this vote
        //                        currentNumberOfVote++;
        //                        // set the updated value into the selected votes
        //                        votes[thisVote - 1] = currentNumberOfVote.ToString();
        //                    }
        //                    else
        //                    {
        //                        votes = new string[] { "0", "0", "0", "0", "0" };
        //                        votes[thisVote - 1] = "1";
        //                    }
        //                }
        //                else
        //                {
        //                    votes = new string[] { "0", "0", "0", "0", "0" };
        //                    votes[thisVote - 1] = "1";
        //                }

        //                // concatenate all arrays now
        //                foreach (string ss in votes)
        //                {
        //                    updatedVotes += ss + ",";
        //                }
        //                updatedVotes = updatedVotes.Substring(0, updatedVotes.Length - 1);

        //                db.Entry(sch).State = EntityState.Modified;
        //                sch.Votes = updatedVotes;
        //                db.SaveChanges();

        //                VoteModel vm = new VoteModel()
        //                {
        //                    Active = true,
        //                    SectionId = Int16.Parse(s),
        //                    UserName = User.Identity.Name,
        //                    Vote = thisVote,
        //                    VoteForId = autoId
        //                };

        //                db.VoteModels.Add(vm);

        //                db.SaveChanges();

        //                // keep the school voting flag to stop voting by this member
        //                HttpCookie cookie = new HttpCookie(url, "true");
        //                Response.Cookies.Add(cookie);
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //    return Json("<br />You rated " + r + " star(s), thanks !");
        //}
    }
}