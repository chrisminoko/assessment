using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class EventDetailStatusController : Controller
    {
        private TestEntities db = new TestEntities();

        // GET: EventDetailStatus
        public ActionResult Index()
        {
            return View(db.EventDetailStatus.ToList());
        }

        // GET: EventDetailStatus/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetailStatu eventDetailStatu = db.EventDetailStatus.Find(id);
            if (eventDetailStatu == null)
            {
                return HttpNotFound();
            }
            return View(eventDetailStatu);
        }

        // GET: EventDetailStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventDetailStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventDetailStatusID,EvenDetailStatusName")] EventDetailStatu eventDetailStatu)
        {
            if (ModelState.IsValid)
            {
                db.EventDetailStatus.Add(eventDetailStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventDetailStatu);
        }

        // GET: EventDetailStatus/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetailStatu eventDetailStatu = db.EventDetailStatus.Find(id);
            if (eventDetailStatu == null)
            {
                return HttpNotFound();
            }
            return View(eventDetailStatu);
        }

        // POST: EventDetailStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventDetailStatusID,EvenDetailStatusName")] EventDetailStatu eventDetailStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventDetailStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventDetailStatu);
        }

        // GET: EventDetailStatus/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetailStatu eventDetailStatu = db.EventDetailStatus.Find(id);
            if (eventDetailStatu == null)
            {
                return HttpNotFound();
            }
            return View(eventDetailStatu);
        }

        // POST: EventDetailStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            EventDetailStatu eventDetailStatu = db.EventDetailStatus.Find(id);
            db.EventDetailStatus.Remove(eventDetailStatu);
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
