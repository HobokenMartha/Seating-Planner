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
            Event e1 = new Event { EventId = 1, Name = "Event 1", createdBy = 1, Venue = "Test Venue", StartDate = DateTime.Parse("16/02/2014 19:00:00"), EndDate = DateTime.Parse("16/02/2014 23:30:00"), Budget = 150.00 };
            Event e2 = new Event { EventId = 1, Name = "Event 2", createdBy = 1, Venue = "Another Venue", StartDate = DateTime.Parse("17/02/2014 19:00:00"), EndDate = DateTime.Parse("17/02/2014 23:30:00"), Budget = 150.00 };
            Guest g1 = new Guest { GuestId = 1, Title = "Mr", FirstName = "Michael", Surname = "O'Brien", Email = "obrienmn@tpg.com.au" };
            Guest g2 = new Guest { GuestId = 2, Title = "Mr", FirstName = "Mike", Surname = "Smith", Email = "mikesmith@tpg.com.au" };
            
            context.Events.Add(e1);
            context.Events.Add(e2);
            context.Guests.Add(g1);
            context.Guests.Add(g2);
            context.SaveChanges();
        }
    }
}
