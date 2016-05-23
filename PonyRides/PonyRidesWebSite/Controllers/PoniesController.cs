using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PonyRidesWebSite.Models.Data;
using System.Net;

namespace PonyRidesWebSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PoniesController : Controller
    {
        private PonyContext db = new PonyContext();

        // GET: Ponies1
        public ActionResult Index()
        {
            return View(db.Ponies.ToList());
        }

        // GET: Ponies1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pony pony = db.Ponies.Find(id);
            if (pony == null)
            {
                return HttpNotFound();
            }
            return View(pony);
        }

        // GET: Ponies1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ponies1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Picture")] Pony pony)
        {
            if (ModelState.IsValid)
            {
                db.Ponies.Add(pony);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pony);
        }

        // GET: Ponies1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pony pony = db.Ponies.Find(id);
            if (pony == null)
            {
                return HttpNotFound();
            }
            return View(pony);
        }

        // POST: Ponies1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Picture")] Pony pony)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pony).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pony);
        }

        // GET: Ponies1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pony pony = db.Ponies.Find(id);
            if (pony == null)
            {
                return HttpNotFound();
            }
            return View(pony);
        }

        // POST: Ponies1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pony pony = db.Ponies.Find(id);
            db.Ponies.Remove(pony);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}