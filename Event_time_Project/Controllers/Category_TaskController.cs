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
    public class Category_TaskController : Controller
    {
        private SoccetContext db = new SoccetContext();

        // GET: Category_Task
        public ActionResult Index()
        {
            return View(db.Category_Tasks.ToList());
        }

        // GET: Category_Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Task category_Task = db.Category_Tasks.Find(id);
            if (category_Task == null)
            {
                return HttpNotFound();
            }
            return View(category_Task);
        }

        // GET: Category_Task/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category_Task/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Category_Id,Name")] Category_Task category_Task)
        {
            if (ModelState.IsValid)
            {
                db.Category_Tasks.Add(category_Task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category_Task);
        }

        // GET: Category_Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Task category_Task = db.Category_Tasks.Find(id);
            if (category_Task == null)
            {
                return HttpNotFound();
            }
            return View(category_Task);
        }

        // POST: Category_Task/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Category_Id,Name")] Category_Task category_Task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_Task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_Task);
        }

        // GET: Category_Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Task category_Task = db.Category_Tasks.Find(id);
            if (category_Task == null)
            {
                return HttpNotFound();
            }
            return View(category_Task);
        }

        // POST: Category_Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category_Task category_Task = db.Category_Tasks.Find(id);
            db.Category_Tasks.Remove(category_Task);
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
