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
    public class EventDetailsController : Controller
    {
        private TestEntities db = new TestEntities();

        // GET: EventDetails
        public ActionResult Index()
        {
            var eventDetails = db.EventDetails.Include(e => e.Event).Include(e => e.EventDetailStatu);
            return View(eventDetails.ToList());
        }

        // GET: EventDetails/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetail eventDetail = db.EventDetails.Find(id);
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventDetail);
        }

        // GET: EventDetails/Create
        public ActionResult Create()
        {
            ViewBag.FK_EventID = new SelectList(db.Events, "EventID", "EventName");
            ViewBag.FK_EventDetailStatusID = new SelectList(db.EventDetailStatus, "EventDetailStatusID", "EvenDetailStatusName");
            return View();
        }

        // POST: EventDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventDetailID,FK_EventDetailStatusID,FK_EventID,EventDetailName,EventDetailNumber,EventDetailOdd,FinishingPosition,FirstTimer")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                db.EventDetails.Add(eventDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FK_EventID = new SelectList(db.Events, "EventID", "EventName", eventDetail.FK_EventID);
            ViewBag.FK_EventDetailStatusID = new SelectList(db.EventDetailStatus, "EventDetailStatusID", "EvenDetailStatusName", eventDetail.FK_EventDetailStatusID);
            return View(eventDetail);
        }

        // GET: EventDetails/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetail eventDetail = db.EventDetails.Find(id);
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_EventID = new SelectList(db.Events, "EventID", "EventName", eventDetail.FK_EventID);
            ViewBag.FK_EventDetailStatusID = new SelectList(db.EventDetailStatus, "EventDetailStatusID", "EvenDetailStatusName", eventDetail.FK_EventDetailStatusID);
            return View(eventDetail);
        }

        // POST: EventDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventDetailID,FK_EventDetailStatusID,FK_EventID,EventDetailName,EventDetailNumber,EventDetailOdd,FinishingPosition,FirstTimer")] EventDetail eventDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FK_EventID = new SelectList(db.Events, "EventID", "EventName", eventDetail.FK_EventID);
            ViewBag.FK_EventDetailStatusID = new SelectList(db.EventDetailStatus, "EventDetailStatusID", "EvenDetailStatusName", eventDetail.FK_EventDetailStatusID);
            return View(eventDetail);
        }

        // GET: EventDetails/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventDetail eventDetail = db.EventDetails.Find(id);
            if (eventDetail == null)
            {
                return HttpNotFound();
            }
            return View(eventDetail);
        }

        // POST: EventDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            EventDetail eventDetail = db.EventDetails.Find(id);
            db.EventDetails.Remove(eventDetail);
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
