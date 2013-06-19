using System;
using Seating_Planner.Persistence.BaseClasses;
using Seating_Planner.Persistence.Interfaces;
using Seating_Planner.Persistence;
using Seating_Planner.Models;

namespace Seating_Planner.Persistence
{
    public class EventRepository : RepositoryBase<event_details>, IEventRepository
    {
        #region Constructors

        public EventRepository(IDBContextFactory context)
            : base(context)
        {
        }

        #endregion
    }
}
