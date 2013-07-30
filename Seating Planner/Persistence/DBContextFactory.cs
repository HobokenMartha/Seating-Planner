using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seating_Planner.Models;
using Seating_Planner.Persistence.Interfaces;

namespace Seating_Planner.Persistence
{
    public class DBContextFactory : IDBContextFactory
    {
        private readonly DbContext _context;

        public DBContextFactory()
        {
            _context = new SeatingPlannerEntities();
        }

        public DbContext GetDBContext()
        {
            return _context;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
