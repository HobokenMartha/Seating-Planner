using System;
using Seating_Planner.Persistence.BaseClasses;
using Seating_Planner.Models;

namespace Seating_Planner.Persistence
{
    public class TableRepository : RepositoryBase<table>
    {
        #region Fields

        private static Type m_ContextType = typeof(table);
        private static string m_Edm = "Model.SeatingPlannerEntityDataModel";

        #endregion

        #region Constructors

        public TableRepository(string filePath)
            : base(filePath, m_ContextType, m_Edm)
        {
        }

        #endregion
    }
}
