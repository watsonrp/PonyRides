using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PonyRidesWebSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }        
        
        // GET: Pony List
        public ActionResult EditPonies()
        {
            return View();
        }
    }
}