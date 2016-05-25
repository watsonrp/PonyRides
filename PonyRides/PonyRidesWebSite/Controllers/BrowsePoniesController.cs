using PonyRidesWebSite.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DayPilot.Web.Mvc;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Book(Booking booking)
        {
            if (ModelState.IsValid)
            {
                using (PonyContext db = new PonyContext())
                {
                    db.Bookings.Add(booking);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(booking);
        }


        public ActionResult Backend()
        {
            return new Dpc().CallBack(this);
        }

        class Dpc : DayPilotCalendar
        {

            protected override void OnInit(InitArgs e)
            {
                Update(CallBackUpdateType.Full);
            }

            protected override void OnEventResize(EventResizeArgs e)
            {
            }

            protected override void OnEventMove(EventMoveArgs e)
            {
            }

            protected override void OnTimeRangeSelected(TimeRangeSelectedArgs e)
            {
            }

            protected override void OnFinish()
            {
                if (UpdateType == CallBackUpdateType.None)
                {
                    return;
                }

            }

        }

    }
}