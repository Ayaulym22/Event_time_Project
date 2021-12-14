using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event_time_Project.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Hello world!";
            return View("Index");
        }
    }
}