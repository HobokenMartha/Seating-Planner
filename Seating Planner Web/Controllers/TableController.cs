using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seating_Planner_Data;
using WebMatrix.WebData;

namespace Seating_Planner_Web.Controllers
{
    public class TableController : Controller
    {
        private SeatingPlannerDbContext db = new SeatingPlannerDbContext(ConfigurationManager.ConnectionStrings["SeatingPlannerContext"].ConnectionString);

        //
        // GET: /Table/5
        // ID relates to the Event ID

        public ActionResult Index(int id)
        {
            return View();
        }

        //
        // GET: /Table/Details/5

        public ActionResult Details(int id)
        {
            Table t = db.Tables.Find(id);
            return View(t);
        }

        //
        // GET: /Table/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Table/Create

        [HttpPost]
        public ActionResult Create(Table table)
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
        // GET: /Table/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Table/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Table table)
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
        // GET: /Table/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Table/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Table table)
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
