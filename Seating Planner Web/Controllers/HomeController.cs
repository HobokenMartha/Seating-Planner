using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seating_Planner_Data;
using System.Diagnostics;

namespace Seating_Planner_Web.Controllers
{
    public class HomeController : Controller
    {
        private SeatingPlannerDbContext db;
        
        public ActionResult Index()
        {
            Debug.Write(ConfigurationManager.ConnectionStrings["SeatingPlannerContext"].ConnectionString);

            db = new SeatingPlannerDbContext(ConfigurationManager.ConnectionStrings["SeatingPlannerContext"].ConnectionString);
            db.Database.Initialize(false);

            var q = from d in db.Guests
                    select new { d.Email };
            
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
