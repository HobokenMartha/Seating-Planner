﻿using System;
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
            Event e1 = new Event { EventId = 1, Name = "30th Birthday", createdBy = 1, Venue = "Test Venue", StartDate = DateTime.Parse("16/02/2014 19:00:00"), EndDate = DateTime.Parse("16/02/2014 23:30:00"), Budget = 500.00 };
            Event e2 = new Event { EventId = 2, Name = "Wedding", createdBy = 1, Venue = "Some Fancy Joint", StartDate = DateTime.Parse("17/02/2014 19:00:00"), EndDate = DateTime.Parse("17/02/2014 23:30:00"), Budget = 20000.00 };
            Guest g1 = new Guest { GuestId = 1, Title = "Mr", FirstName = "Michael", Surname = "O'Brien", Email = "obrienmn@tpg.com.au", CreatedBy = 1, DateTimeCreated = DateTime.Now };
            Guest g2 = new Guest { GuestId = 2, Title = "Mr", FirstName = "Mike", Surname = "Smith", Email = "mikesmith@tpg.com.au", CreatedBy = 1, DateTimeCreated = DateTime.Now };
            Guest g3 = new Guest { GuestId = 3, Title = "Mr", FirstName = "Alan", Surname = "O'Brien", Email = "aob@tpg.com.au", CreatedBy = 1, DateTimeCreated = DateTime.Now };
            Table t1 = new Table { TableId = 1, Name = "Table 1", Capacity = 6 , xCoordinate = 10, yCoordinate = 50};
            Table t2 = new Table { TableId = 2, Name = "Table 2", Capacity = 4 , xCoordinate = 20, yCoordinate = 100};

            List<Guest> guests = new List<Guest>();
            guests.Add(g1);
            guests.Add(g2);
            guests.Add(g3);

            List<Table> tables = new List<Table>();
            tables.Add(t1);
            tables.Add(t2);

            context.Events.Add(e1);
            context.Events.Add(e2);

            context.SaveChanges();


            var ev = context.Events.Find(1);
            ev.Guests = guests;
            ev.Tables = tables;
            
            context.SaveChanges();
        }
    }
}
