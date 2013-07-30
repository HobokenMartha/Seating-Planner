using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Seating_Planner.Models;
using Seating_Planner.Commands;

namespace Seating_Planner.ViewModels
{
    public class LoadEventViewModel : ViewModelBase
    {
        #region Properties

        private ObservableCollection<event_detail> m_Events;
        private event_detail m_SelectedEvent;

        #endregion

        #region Command Properties

        public ICommand LoadEvents { get; set; }

        #endregion

        #region Constructors

        public LoadEventViewModel()
        {
            this.Initialise();
        }

        #endregion

        #region Data Properties

        public event_detail SelectedEvent
        {
            get
            {
                return m_SelectedEvent;
            }
            set
            {
                base.RaisePropertyChangingEvent("SelectedEvent");
                m_SelectedEvent = value;
                base.RaisePropertyChangedEvent("SelectedEvent");
            }
        }

        public ObservableCollection<event_detail> Events
        {
            get
            {
                return m_Events;
            }
            set
            {
                base.RaisePropertyChangingEvent("Events");
                m_Events = value;
                base.RaisePropertyChangedEvent("Events");
            }
        }

        #endregion

        #region Event Handlers

        //TODO: Add properties
        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                default:
                    break;
            }
        }

        //TODO: Add properties
        void OnPropertyChanging(object sender, System.ComponentModel.PropertyChangingEventArgs e)
        {
            switch (e.PropertyName)
            {
                default:
                    break;
            }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void Initialise()
        {
            this.PropertyChanging += OnPropertyChanging;
            this.PropertyChanged += OnPropertyChanged;

            //TODO: Do we need a new command for this window or should the existing one be refactored?
            //this.LoadEvents = new LoadEventCommand(null);
        }

        #endregion
    }
}
