using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using Seating_Planner.Persistence;
using Seating_Planner.Persistence.Interfaces;

namespace Seating_Planner.Persistence.BaseClasses
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties
                
        private DbContext m_DBContext;
        private DbSet<T> m_DBSet;
        private bool m_UsingSharedObjectContext;

        #endregion

        #region Constructors

        protected RepositoryBase(IDBContextFactory context)
        {
            m_DBContext = context.GetDBContext();
            m_DBSet = m_DBContext.Set<T>();
            m_UsingSharedObjectContext = false;
        }

        #endregion

        #region Public Methods

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            m_DBSet.Add(entity);
            SaveChanges();
        }

        public void Attach(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            m_DBSet.Attach(entity);
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            m_DBSet.Remove(entity);
        }

        public void Remove(Expression<Func<T, bool>> predicate)
        {
            var records = from x in m_DBSet.Where(predicate) select x;
            foreach (T record in records)
            {
                m_DBSet.Remove(record);
            }
        }

        /// <summary>
        /// Releases all resources used by the Repository.
        /// </summary>
        public void Dispose()
        {
            /* See http://msdn.microsoft.com/en-us/library/system.idisposable.dispose.aspx */

            // Call the protected method in this class
            var disposeOfObjectContext = (m_UsingSharedObjectContext == false);
            Dispose(disposeOfObjectContext);

            // Dispose() will finalize this object, so take it out of the queue
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> Fetch()
        {
            // Get object set
            var dbset = m_DBSet;

            return dbset;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            // Get object set
            var dbset = m_DBSet.Where(predicate);

            return dbset;
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            // Get object set
            var dbset = m_DBSet.First(predicate);

            // Set return value
            return dbset;
        }

        public IEnumerable<T> GetAll()
        {
            // Get object set
            var dbset = Fetch().AsEnumerable();

            // Set return value
            return dbset;
        }

        public void SaveChanges()
        {
            // Save changes
            m_DBContext.SaveChanges();
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            // Get object set
            var dbset = m_DBSet.Single(predicate);

            // Set return value
            return dbset;
        }        

        #endregion

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (m_DBContext == null) return;

            m_DBContext.Dispose();
            m_DBContext = null;
        }

        #endregion

        #region Private Methods

        private DbContext CreateDBContext()
        {
            return m_DBContext;
        }

        #endregion
    }
}
