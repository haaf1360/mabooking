using Mabooking.Models;
using Mabooking.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mabooking.Areas.AdminPanel.Controllers
{
    public class RoutsController : Controller
    {

       DataContext Context = new DataContext();
        // GET: AdminPanel/Routs
        public ActionResult Index()
        {
            List<Models.Entities.Routs> Routs = Context.RoutsCollection.ToList();
            return View(Routs);
        }

        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.Entities.Routs Rout)
        {
            Context.RoutsCollection.Add(Rout);
            Context.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Edit(int Id)
        {
            Models.Entities.Routs rout = Context.RoutsCollection.Find(Id);
            return View(rout);
        }
        [HttpPost]
        public ActionResult Edit(Models.Entities.Routs Rout)
        {
            Context.Entry(Rout).State = System.Data.Entity.EntityState.Modified;
            Context.SaveChanges();
            return RedirectToAction("index");
        } 

        public ActionResult Delete(int Id)
        {
            Models.Entities.Routs rout = Context.RoutsCollection.Find(Id);
            Context.RoutsCollection.Remove(rout);
            Context.SaveChanges();
            return RedirectToAction("index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
                base.Dispose(disposing);
            }
         
        }
    }
}