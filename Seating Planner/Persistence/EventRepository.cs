using System;
using Seating_Planner.Persistence.BaseClasses;
using Seating_Planner.Models;

namespace Seating_Planner.Persistence
{
    public class EventRepository : RepositoryBase<event_details>
    {
        #region Fields

        private static Type m_ContextType = typeof(event_details);
        private static string m_Edm = "Model.SeatingPlannerEntityDataModel";

        #endregion

        #region Constructors

        public EventRepository(string filePath)
            : base(filePath, m_ContextType, m_Edm)
        {
        }

        #endregion
    }
}
