using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Event_time_Project.Models;

namespace Event_time_Project.Controllers
{
    public class UsersController : Controller
    {
        private SoccetContext db = new SoccetContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Calendar).Include(u => u.Event).Include(u => u.Task);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.Calendar_id = new SelectList(db.Calendars, "Calendar_id", "Calendar_id");
            ViewBag.Event_id = new SelectList(db.Events, "Event_id", "Subject");
            ViewBag.Task_id = new SelectList(db.Task, "Task_id", "Task_name");
            return View();
        }

        // POST: Users/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "User_id,User_name,Surname,Login,Password,Phone,Event_id,Task_id,Calendar_id")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Calendar_id = new SelectList(db.Calendars, "Calendar_id", "Calendar_id", user.Calendar_id);
            ViewBag.Event_id = new SelectList(db.Events, "Event_id", "Subject", user.Event_id);
            ViewBag.Task_id = new SelectList(db.Task, "Task_id", "Task_name", user.Task_id);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.Calendar_id = new SelectList(db.Calendars, "Calendar_id", "Calendar_id", user.Calendar_id);
            ViewBag.Event_id = new SelectList(db.Events, "Event_id", "Subject", user.Event_id);
            ViewBag.Task_id = new SelectList(db.Task, "Task_id", "Task_name", user.Task_id);
            return View(user);
        }

        // POST: Users/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "User_id,User_name,Surname,Login,Password,Phone,Event_id,Task_id,Calendar_id")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Calendar_id = new SelectList(db.Calendars, "Calendar_id", "Calendar_id", user.Calendar_id);
            ViewBag.Event_id = new SelectList(db.Events, "Event_id", "Subject", user.Event_id);
            ViewBag.Task_id = new SelectList(db.Task, "Task_id", "Task_name", user.Task_id);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
