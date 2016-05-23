using PonyRidesWebSite.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PonyRidesWebSite.Controllers
{
    public class BrowsePoniesController : Controller
    {

        // GET: BrowsePonies
        public ActionResult Index()
        {
            PonyContext db = new PonyContext();
            return View(db.Ponies.ToList());
        }

        // GET: Book
        public ActionResult Book(string _ID)
        {
            PonyContext db = new PonyContext();
            //Pony pony = db.Ponies.Find(_ID);

            return View();
        }

        // POST: Book
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book(Booking booking)
        {
            if (ModelState.IsValid)
            {
                //db.Bookings.Add(booking);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }
    }
}