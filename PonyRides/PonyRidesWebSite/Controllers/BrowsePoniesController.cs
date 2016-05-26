using PonyRidesWebSite.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


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
        [Authorize]
        public ActionResult Book(int id)
        {
            PonyContext db = new PonyContext();
            Pony pony = db.Ponies.Find(id);
            Booking booking = new Booking();
            ViewBag.Pony = pony.Name;
            ViewBag.Picture = pony.Picture;
            ViewBag.PonyID = pony.ID;
            ViewBag.CustomerID = User.Identity.GetUserId();
            booking.Day = DateTime.Today;
            booking.PonyID = pony.ID;
            booking.CustomerID = User.Identity.GetUserId();
            return View(booking);
        }

        // POST: Book
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book(Booking booking)
        {
            if (ModelState.IsValid)
            {
                if (!BookingClash(booking))
                {
                    using (PonyContext db = new PonyContext())
                    {
                        db.Bookings.Add(booking);
                        db.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    using (PonyContext db = new PonyContext())
                    {
                        Pony pony = db.Ponies.Find(booking.PonyID);
                        ViewBag.Pony = pony.Name;
                        ViewBag.Picture = pony.Picture;
                        ViewBag.PonyID = pony.ID;
                        ViewBag.CustomerID = User.Identity.GetUserId();
                        ModelState.AddModelError("", "Cannot book as there is a clash. Please choose another time, pony, or day.");
                        return View(booking);
                    }
                }
            }
            return View(booking);
        }

        Boolean BookingClash(Booking theBooking)
        {
            using (PonyContext db = new PonyContext())
            {
                foreach(Booking booking in db.Bookings.Where(x => x.Day == theBooking.Day).ToList())
                {
                    if (theBooking.PonyID   == booking.PonyID   &&
                        theBooking.Session  == booking.Session)
                        return true;
                }
            }
            return false;
        }

    }
}