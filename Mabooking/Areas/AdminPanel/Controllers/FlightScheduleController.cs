using Mabooking.Models;
using Mabooking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mabooking.Areas.AdminPanel.Controllers
{
    public static class ShowRouteNumber
    {
        public static string GetNumber(long routeid)
        {
            string value = "";
            using (DataContext db=new DataContext())
            {
                value = db.RoutsCollection.Find(routeid).FlightNumber;
            }
            return value;
        }
    }
    public class FlightScheduleController : Controller
    {
        DataContext Context = new DataContext();
        // GET: AdminPanel/FlightSchedule
        public ActionResult Index()
        {
            List<FlightsSchedule> flightSchedules = Context.ScheduleCollection.ToList();
            return View(flightSchedules);
        }

        public ActionResult Create()
        {
            ViewBag.FlightNumber = Context.RoutsCollection.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(FlightsSchedule flightsSchedule)
        {
            Context.ScheduleCollection.Add(flightsSchedule);
            Context.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Edit(int Id)
        {
            
            FlightsSchedule FlightsSchedule = Context.ScheduleCollection.Find(Id);
            ViewBag.Routs_Id = new SelectList(Context.RoutsCollection, "Id", "FlightNumber", FlightsSchedule.Routs_Id);
            return View(FlightsSchedule);
        }
        [HttpPost]
        public ActionResult Edit(FlightsSchedule FlightsSchedule)
        {
            ViewBag.Routs_Id = new SelectList(Context.RoutsCollection, "Id", "FlightNumber", FlightsSchedule.Routs_Id);

            Context.Entry(FlightsSchedule).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}