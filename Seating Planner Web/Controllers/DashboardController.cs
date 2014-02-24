using System;
using System.Collections.Generic;
using System.Configuration;
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
        private SeatingPlannerDbContext db = new SeatingPlannerDbContext(ConfigurationManager.ConnectionStrings["SeatingPlannerContext"].ConnectionString);

        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            ViewBag.Title = "My Dashboard";
            return View();
        }
    }
}
