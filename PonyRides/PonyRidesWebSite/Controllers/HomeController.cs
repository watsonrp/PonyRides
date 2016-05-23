using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PonyRidesWebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Pony Rides is developed by Pixies.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pony Rides Management";

            return View();
        }
    }
}