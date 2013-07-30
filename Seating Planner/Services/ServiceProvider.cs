using System;
using System.Collections.Generic;

namespace Seating_Planner.Services
{
    public class ServiceProvider : IServiceProvider
    {
        Dictionary<Type, object> services = new Dictionary<Type, object>();

        #region ServiceProvider Methods

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public bool RegisterService<T>(T service, bool overwriteIfExists)
        {
            if (service == null)
            {
                throw new ArgumentNullException("Service");
            }
            lock (services)
            {
                if (!services.ContainsKey(typeof(T)))
                {
                    services.Add(typeof(T), service);
                    return true;
                }
                else if (overwriteIfExists)
                {
                    services[typeof(T)] = service;
                    return true;
                }
            }
            return false;
        }

        public bool RegisterService<T>(T service)
        {
            return RegisterService<T>(service, false);
        }

        public object GetService(Type serviceType)
        {
            lock (services)
            {
                if (services.ContainsKey(serviceType))
                    return services[serviceType];
            }
            return null;
        }

        public void Remove(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            lock (services)
            {
                services.Remove(type);
            }
        }

        public void Clear()
        {
            if (services != null && services.Count > 0)
                services.Clear();
        }

        #endregion
    }
}
