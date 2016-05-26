using PonyRidesWebSite.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PonyRidesWebSite.Models;

namespace PonyRidesWebSite.Controllers
{
    public class MyBookingsController : Controller
    {

        // GET: MyBookings
        [Authorize]
        public ActionResult Index()
        {
            using (PonyContext db = new PonyContext())
            {
                var userid = User.Identity.GetUserId();
                List<Booking> bookings = db.Bookings.Where(x => x.CustomerID == userid).OrderBy(x => x.Day).ToList();
                List<BookingList> bookingsList = new List<BookingList>();
                BookingList bookingList;
                foreach(Booking booking in bookings)
                {
                    bookingList = new BookingList();
                    bookingList.Day = booking.Day.ToShortDateString();
                    bookingList.Session = getSession(booking.Session);
                    bookingList.PonyName = db.Ponies.Find(booking.PonyID).Name;
                    bookingList.PonyPicture = db.Ponies.Find(booking.PonyID).Picture;
                    bookingList.SessionID = booking.ID;
                    bookingsList.Add(bookingList);
                }
                return View(bookingsList);
            }
        }

        //// GET: MyBookings/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            try
            {
                using (PonyContext db = new PonyContext())
                {
                    Booking booking = db.Bookings.Find(id);
                    if (booking != null)
                    {
                        db.Bookings.Remove(booking);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: MyBookings/Delete/5
        //[Authorize]
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        using (PonyContext db = new PonyContext())
        //        {
        //            Pony pony = db.Ponies.Find(id);
        //            if (pony != null)
        //                db.Ponies.Remove(pony);
        //        }
        //            return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        string getSession(int session)
        {
            string val;
            switch (session)
            {
                case 1:
                    val = "Morning";
                    break;
                case 2:
                    val = "Afternoon";
                    break;
                case 3:
                    val = "Evening";
                    break;
                default:
                    val = "Morning";
                    break;

            }
            return val;
        }

    }
}
