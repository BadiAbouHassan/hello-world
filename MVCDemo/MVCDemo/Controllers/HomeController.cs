using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Hunting License";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "this is the about message of about page ";
            return View();
        }
    }
}
