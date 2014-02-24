using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seating_Planner_Data;

namespace Seating_Planner_Web.Controllers
{
    public class GuestController : Controller
    {
        private SeatingPlannerDbContext db = new SeatingPlannerDbContext(ConfigurationManager.ConnectionStrings["SeatingPlannerContext"].ConnectionString);

        //
        // GET: /Guest/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Guest/Details/5

        public ActionResult Details(int id)
        {
            Guest g = db.Guests.Find(id);

            return View(g);
        }

        //
        // GET: /Guest/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Guest/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Guest/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Guest/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Guest/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Guest/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
