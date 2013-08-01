using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seating_Planner.Events;
using Seating_Planner.Services;
using Seating_Planner.Services.Interfaces;

namespace Seating_Planner.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        /// <summary>
        /// Service resolver for view models.  Allows derived types to add/remove
        /// services from mapping.
        /// </summary>
        public static readonly ServiceProvider ServiceProvider = new ServiceProvider();

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// This event should be raised to close the view.  Any view tied to this
        /// ViewModel should register a handler on this event and close itself when
        /// this event is raised.  If the view is not bound to the lifetime of the
        /// ViewModel then this event can be ignored.
        /// </summary>
        public event EventHandler<CloseRequestEventArgs> CloseRequest = delegate { };

        /// <summary>
        /// This event should be raised to activate the UI.  Any view tied to this
        /// ViewModel should register a handler on this event and close itself when
        /// this event is raised.  If the view is not bound to the lifetime of the
        /// ViewModel then this event can be ignored.
        /// </summary>
        public event EventHandler ActivateRequest = delegate { };

        /// <summary>
        /// This resolves a service type and returns the implementation.
        /// </summary>
        /// <typeparam name="T">Type to resolve</typeparam>
        /// <returns>Implementation</returns>
        protected T GetService<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        protected bool IgnorePropertyChangeEvents { get; set; }

        public void RaisePropertyChangedEvent(string propertyName)
        {
            if (IgnorePropertyChangeEvents) return;

            if (PropertyChanged == null) return;

            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged(this, e);
        }

        public void RaisePropertyChangingEvent(string propertyName)
        {
            if (IgnorePropertyChangeEvents) return;

            if (PropertyChanging == null) return;

            var e = new PropertyChangingEventArgs(propertyName);
            PropertyChanging(this, e);
        }

        /// <summary>
        /// This raises the ActivateRequest event to activate the UI.
        /// </summary>
        public void RaiseActivateRequest()
        {
            ActivateRequest(this, EventArgs.Empty);
        }

        /// <summary>
        /// This raises the CloseRequest event to close the UI.
        /// </summary>
        public void RaiseCloseRequest()
        {
            CloseRequest(this, new CloseRequestEventArgs(null));
        }

        /// <summary>
        /// This raises the CloseRequest event to close the UI.
        /// </summary>
        public virtual void RaiseCloseRequest(bool? dialogResult)
        {
            CloseRequest(this, new CloseRequestEventArgs(dialogResult));
        }
    }
}
