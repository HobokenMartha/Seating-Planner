using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using Seating_Planner_Web.Filters;
using Seating_Planner_Web.Models;
using Seating_Planner_Data;

namespace Seating_Planner_Web.Controllers
{
    public class EventController : Controller
    {
        private SeatingPlannerDbContext db;        
                
        //
        // GET: /Event/
        [Authorize]
        public ActionResult Index()
        {
            int id = WebSecurity.CurrentUserId;
            using (db = new SeatingPlannerDbContext(ConfigurationManager.ConnectionStrings["SeatingPlannerContext"].ConnectionString))
            {
                var myEvents = from d in db.Events
                               where d.createdBy == id                             
                               orderby d.Name
                               select d;

                return View(myEvents.ToList<Event>());
            }
        }

        //
        // GET: /Event/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Event/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Event/Create

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
        // GET: /Event/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Event/Edit/5

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
        // GET: /Event/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Event/Delete/5

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
