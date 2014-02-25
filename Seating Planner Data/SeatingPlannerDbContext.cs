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
            : base(ConnString) 
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new SeatingPlannerDbInitialiser());
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events {get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }
}
