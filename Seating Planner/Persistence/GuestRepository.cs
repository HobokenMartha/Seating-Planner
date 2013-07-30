using System;
using Seating_Planner.Persistence.BaseClasses;
using Seating_Planner.Persistence.Interfaces;
using Seating_Planner.Persistence;
using Seating_Planner.Models;

namespace Seating_Planner.Persistence
{
    public class GuestRepository : RepositoryBase<guest>, IGuestRepository
    {
        #region Constructors

        public GuestRepository(IDBContextFactory context)
            : base(context)
        {
        }

        #endregion
    }
}
