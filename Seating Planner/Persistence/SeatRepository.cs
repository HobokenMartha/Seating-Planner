using System;
using Seating_Planner.Persistence.BaseClasses;
using Seating_Planner.Persistence.Interfaces;
using Seating_Planner.Persistence;
using Seating_Planner.Models;

namespace Seating_Planner.Persistence
{
    public class SeatRepository : RepositoryBase<seat>, ISeatRepository
    {
        #region Constructors

        public SeatRepository(IDBContextFactory context)
            : base(context)
        {
        }

        #endregion
    }
}
