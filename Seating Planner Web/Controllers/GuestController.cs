using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Seating_Planner_Data;
using WebMatrix.WebData;

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

        public ActionResult Create(int id)
        {
            ViewData["EventId"] = id;
            return View();
        }

        //
        // POST: /Guest/Create

        [HttpPost]
        public ActionResult Create(Guest guest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    guest.CreatedBy = WebSecurity.CurrentUserId;
                    guest.DateTimeCreated = DateTime.Now;
                    db.Guests.Add(guest);
                    db.SaveChanges();
                }

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
        public ActionResult Edit(int id, Guest guest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(guest).State = EntityState.Modified;
                    db.SaveChanges();
                }

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
        public ActionResult Delete(int id, Guest guest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(guest).State = EntityState.Deleted;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
