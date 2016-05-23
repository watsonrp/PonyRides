using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PonyRidesWebSite.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        // GET: Booking
        public ActionResult Index()
        {
            // get list of ponies
            return View();
        }
    }
}