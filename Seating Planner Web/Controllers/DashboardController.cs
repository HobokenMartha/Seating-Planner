using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.Data;
using Seating_Planner_Data;
using Seating_Planner_Web.Filters;
using Seating_Planner_Web.Models;

namespace Seating_Planner_Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private SeatingPlannerDbContext db;

        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            ViewBag.Title = "My Dashboard";
            return View();
        }

        //
        // GET: /Dashboard/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Dashboard/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Dashboard/Create

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
        // GET: /Dashboard/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Dashboard/Edit/5

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
        // GET: /Dashboard/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Dashboard/Delete/5

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
