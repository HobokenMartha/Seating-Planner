using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using Seating_Planner.Persistence.Interfaces;

namespace Seating_Planner.Persistence.BaseClasses
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {

        #region Properties
        
        private ObjectContext m_ObjectContext;
        private IObjectSet<T> m_ObjectSet;
        private bool m_UsingSharedObjectContext;

        #endregion

        #region Constructors

        protected RepositoryBase(string filePath, Type contextType, string edm)
        {

        }

        #endregion

        #region Public Methods

        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            m_ObjectSet.AddObject(entity);
        }

        public void Attach(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            m_ObjectSet.Attach(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            m_ObjectSet.DeleteObject(entity);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            var records = from x in m_ObjectSet.Where(predicate) select x;
            foreach (T record in records)
            {
                m_ObjectSet.DeleteObject(record);
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
            var objectSet = m_ObjectSet;

            return objectSet;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            // Get object set
            var objectSet = m_ObjectSet.Where(predicate);

            return objectSet;
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            // Get object set
            var objectSet = m_ObjectSet.First(predicate);

            // Set return value
            return objectSet;
        }

        public IEnumerable<T> GetAll()
        {
            // Get object set
            var objectSet = Fetch().AsEnumerable();

            // Set return value
            return objectSet;
        }

        public void SaveChanges()
        {
            // Save changes
            m_ObjectContext.SaveChanges();
        }

        public void SaveChanges(SaveOptions options)
        {
            // Save changes
            m_ObjectContext.SaveChanges(options);
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            // Get object set
            var objectSet = m_ObjectSet.Single(predicate);

            // Set return value
            return objectSet;
        }        

        #endregion

        #region Protected Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (m_ObjectContext == null) return;

            m_ObjectContext.Dispose();
            m_ObjectContext = null;
        }

        #endregion

        #region Private Methods

        private ObjectContext CreateObjectContext(string filePath, Type contextType, string edm)
        {
            if (edm == null)
            {
                throw new ArgumentNullException("EDM");
            }

            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            var connectionString = string.Format("Data Source={0}", filePath);
            var Builder = new EntityConnectionStringBuilder();

            // Configure Builder
            Builder.Metadata = string.Format("res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl",
                edm);
            Builder.Provider = "System.Data.SQLite";
            Builder.ProviderConnectionString = connectionString;
            var edmConnectionString = Builder.ToString();

            // Create an EDM connection
            EntityConnection edmConnection;
            try
            {
                edmConnection = new EntityConnection(edmConnectionString);

            }
            catch (Exception e)
            {
                // Rethrow exception
                throw;
            }

            /* EF ObjectContext objects are typed to the specific EDM that they
             * represent. The context type is injected into the constructor of
             * this class, and we use the System.Activator.CreateInstance() 
             * method to instantiate an object of that type. */

            // Get the object context
            object objectContext;
            try
            {
                objectContext = Activator.CreateInstance(contextType, edmConnection);
            }
            catch (Exception e)
            {
                // Rethrow exception
                throw;
            }

            // Set return value
            return (ObjectContext)objectContext;

        }

        #endregion
    }
}
