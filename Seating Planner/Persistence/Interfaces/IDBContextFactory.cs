using System;
using System.Data.Entity;

namespace Seating_Planner.Persistence.Interfaces
{
    public interface IDBContextFactory : IDisposable
    {
        DbContext GetDBContext();
    }
}
