using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seating_Planner_Data
{
    public class SeatingPlannerDbContext : DbContext
    {
        public SeatingPlannerDbContext(string ConnString)
            : base(ConnString) { }

        public DbSet<Event> Events;
        public DbSet<Table> Tables;
        public DbSet<Guest> Guests;
    }
}
