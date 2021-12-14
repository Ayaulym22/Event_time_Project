using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Event_time_Project.Controllers
{
    public class LayoutCategoryTasksController : Controller
    {
        // GET: LayoutCategoryTasks
        public ActionResult Index()
        {
            return View("Index", "_Layout3");
        }
        public ActionResult Content()
        {
            return View();
        }

    }
}