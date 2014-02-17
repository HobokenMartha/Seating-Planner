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
            Guest g1 = new Guest { GuestId = 1, Title = "Mr", FirstName = "Michael", Surname = "O'Brien", Email = "obrienmn@tpg.com.au" };
            context.Guests.Add(g1);
            context.SaveChanges();
        }
    }
}
