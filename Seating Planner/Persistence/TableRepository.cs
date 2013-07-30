using System;
using Seating_Planner.Persistence.BaseClasses;
using Seating_Planner.Persistence.Interfaces;
using Seating_Planner.Persistence;
using Seating_Planner.Models;

namespace Seating_Planner.Persistence
{
    public class TableRepository : RepositoryBase<table>, ITableRepository
    {
        #region Constructors

        public TableRepository(IDBContextFactory context)
            : base(context)
        {
        }

        #endregion
    }
}
