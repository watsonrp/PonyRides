using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PonyRidesWebSite.Controllers
{
    public class PoniesController : Controller
    {
        // GET: Ponies
        public ActionResult Index()
        {
            return View();
        }
    }
}