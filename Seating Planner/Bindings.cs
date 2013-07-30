using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using Seating_Planner.Persistence.BaseClasses;
using Seating_Planner.Persistence.Interfaces;
using Seating_Planner.Persistence;

namespace Seating_Planner
{
    /// <summary>
    /// Ninject Bindings
    /// </summary>
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            //Bind interfaces to implementations here
            Bind<IDBContextFactory>().To<DBContextFactory>();
            Bind<IEventRepository>().To<EventRepository>();
            Bind<ITableRepository>().To<TableRepository>();
        }
    }
}
