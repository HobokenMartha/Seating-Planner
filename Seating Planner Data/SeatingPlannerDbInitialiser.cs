using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seating_Planner_Data
{
    /// <summary>
    /// 
    /// </summary>
    public class SeatingPlannerDbInitialiser : DropCreateDatabaseAlways<SeatingPlannerDbContext>
    {
        protected override void Seed(SeatingPlannerDbContext context)
        {
            Event event1 = new Event { EventId = 1, Name = "Test Event", Budget = 0.00, StartDate = DateTime.Now, EndDate = DateTime.Now, Venue = "Test Venue" };
            context.Events.Add(event1);
            context.SaveChanges();
        }
    }
}
