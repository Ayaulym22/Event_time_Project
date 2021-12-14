using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Event_time_Project.Models;
using System.Net;

namespace Event_time_Project.Controllers
{
    public class HomeController : Controller
    {
        SoccetContext db = new SoccetContext();
      public ActionResult Index()
        {
            var tasks = db.Task.Include(p => p.Category_Task);
            return View(tasks.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList categorytasks = new SelectList(db.Category_Tasks, "Category_Id", "Name");
            ViewBag.Category_Tasks = categorytasks;
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Task task)
        {
            db.Task.Add(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
         public ActionResult Edit(int? id)
         {
             if (id == null)
             {
                 return HttpNotFound();
             }
             Task task = db.Task.Find(id);
             if (task != null)
             {
                 SelectList categorytasks = new SelectList(db.Category_Tasks, "Category_Id", "Name", task.Category_Id);
                 ViewBag.Category_Tasks = categorytasks;
                 SelectList notify = new SelectList(db.Notifications, "Notify_Id", "Notify_date", task.Notify_Id);
                 ViewBag.Notifications = notify;
                return View(task);
             }
             return RedirectToAction("Index");
         }

         [HttpPost]
         public ActionResult Edit(Task task)
         {
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
             return RedirectToAction("Index");
         }

         public ActionResult Delete(int? id)
         {
             if (id == null)
             {
                 return HttpNotFound();
             }
             Task task = db.Task.Find(id);
             if (id != null)
             {
                 db.Task.Remove(task);
                 db.SaveChanges();
             }
             return RedirectToAction("Index");
         }

      
     
    }
}
