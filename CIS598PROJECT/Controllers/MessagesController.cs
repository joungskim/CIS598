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

namespace CIS598PROJECT.Models
{
    public class MessagesController : Controller
    {
        private BTBDatabaseEntities2 db = new BTBDatabaseEntities2();

        // GET: Messages
        public ActionResult Index()
        {
            string curUser = User.Identity.GetUserName();
            IEnumerable<Message> messages = db.Messages.OrderBy(i => i.ID).Where(m => m.ToUser.Equals(curUser) || m.FromUser.Equals(curUser));
            return View(messages.ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult NewMessage()
        {
            ViewBag.FromUser = new SelectList(db.Users, "User1", "Email");
            ViewBag.ToUser = new SelectList(db.Users, "User1", "Email");
            Message message = new Message();
            message.Users = db.Users.Where(m => m.Show != false && m.User1 != User.Identity.Name);
            return View(message);
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMessage([Bind(Include = "ID,FromUser,ToUser,Message1,Image,Date,Show")] Message message)
        {
            if (ModelState.IsValid)
            {
                message.Date = DateTime.UtcNow;
                message.Show = 1;
                message.ID = 1 + db.Messages.Count();
                db.Messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FromUser = new SelectList(db.Users, "User1", "Email", message.FromUser);
            ViewBag.ToUser = new SelectList(db.Users, "User1", "Email", message.ToUser);
            message = new Message();
            message.Users = db.Users.Where(m => m.Show != false && m.User1 != User.Identity.Name);
            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromUser = new SelectList(db.Users, "User1", "Email", message.FromUser);
            ViewBag.ToUser = new SelectList(db.Users, "User1", "Email", message.ToUser);
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FromUser,ToUser,Message1,Image,Date,Show")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FromUser = new SelectList(db.Users, "User1", "Email", message.FromUser);
            ViewBag.ToUser = new SelectList(db.Users, "User1", "Email", message.ToUser);
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
