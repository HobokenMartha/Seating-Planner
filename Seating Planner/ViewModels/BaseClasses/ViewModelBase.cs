using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seating_Planner.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public virtual bool IgnorePropertyChangeEvents { get; set; }

        public virtual void RaisePropertyChangedEvent(string propertyName)
        {
            if (IgnorePropertyChangeEvents) return;

            if (PropertyChanged == null) return;

            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged(this, e);
        }

        public virtual void RaisePropertyChangingEvent(string propertyName)
        {
            if (IgnorePropertyChangeEvents) return;

            if (PropertyChanging == null) return;

            var e = new PropertyChangingEventArgs(propertyName);
            PropertyChanging(this, e);
        }
    }
}
