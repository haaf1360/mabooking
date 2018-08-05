using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mabooking.Models;
using Mabooking.Models.Entities;

namespace Mabooking.Areas.AdminPanel.Controllers
{
    public class ReservsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: AdminPanel/Reservs
        public ActionResult Index()
        {
            var reservCollection = db.ReservCollection.Include(r => r.Customer).Include(r => r.FlightsSchedule);
            return View(reservCollection.ToList());
        }

        // GET: AdminPanel/Reservs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserv reserv = db.ReservCollection.Find(id);
            if (reserv == null)
            {
                return HttpNotFound();
            }
            return View(reserv);
        }

        // GET: AdminPanel/Reservs/Create
        public ActionResult Create()
        {
            ViewBag.Customer_Id = new SelectList(db.Customers, "Id", "Name");
            // ViewBag.FlightsSchedule_Id = new SelectList(db.RoutsCollection, "id", "FlightNumber");
         //   Reserv reserv = db.ReservCollection.Find(id);
            ViewBag.FlightsSchedule_Id = new SelectList(db.RoutsCollection.Join(db.ScheduleCollection, it => it.Id, it2 => it2.Routs_Id, (it1, it2) => new { Title = it1.FlightNumber + " " + it2.FltDate, Id = it2.id }), "Id", "Title");

            // ViewBag.flightschedule_Date = new SelectList(db.ScheduleCollection, "id", "FltDate");
            return View();
        }

        // POST: AdminPanel/Reservs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Customer_Id,FlightsSchedule_Id,Weight,Pcs,ULD,Description,UserName,Canceled,RequestedDate,CreateDate")] Reserv reserv)
        {
            if (ModelState.IsValid)
            {
                db.ReservCollection.Add(reserv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_Id = new SelectList(db.Customers, "Id", "Name", reserv.Customer_Id);
            ViewBag.FlightsSchedule_Id = new SelectList(db.RoutsCollection, "id", "FlightNumber", reserv.FlightsSchedule_Id);
            return View(reserv);
        }

        // GET: AdminPanel/Reservs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserv reserv = db.ReservCollection.Find(id);
            if (reserv == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_Id = new SelectList(db.Customers, "Id", "Name", reserv.Customer_Id);

            ViewBag.FlightsSchedule_Id = new SelectList(db.RoutsCollection.Join(db.ScheduleCollection, it => it.Id, it2 => it2.Routs_Id, (it1, it2) => new { Title = it1.FlightNumber+" "+it2.FltDate, Id = it2.id }), "Id", "Title", reserv.FlightsSchedule_Id);
            return View(reserv);
        }

        // POST: AdminPanel/Reservs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Customer_Id,FlightsSchedule_Id,Weight,Pcs,ULD,Description,UserName,Canceled,RequestedDate,CreateDate")] Reserv reserv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserv).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_Id = new SelectList(db.Customers, "Id", "Name", reserv.Customer_Id);

            ViewBag.FlightsSchedule_Id = new SelectList(db.RoutsCollection.Join(db.ScheduleCollection, it => it.Id, it2 => it2.Routs_Id, (it1, it2) => new { Title = it1.FlightNumber+" "+it2.FltDate, Id = it2.id }), "Id", "Title", reserv.FlightsSchedule_Id);
            return View(reserv);
        }

        // GET: AdminPanel/Reservs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserv reserv = db.ReservCollection.Find(id);
            if (reserv == null)
            {
                return HttpNotFound();
            }
            return View(reserv);
        }

        // POST: AdminPanel/Reservs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserv reserv = db.ReservCollection.Find(id);
            db.ReservCollection.Remove(reserv);
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
