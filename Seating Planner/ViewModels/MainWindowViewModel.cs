using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Seating_Planner.Models;
using Seating_Planner.Commands;

namespace Seating_Planner.ViewModels
{
    //TODO: I've been looking here: http://astoundingprogramming.wordpress.com/2012/02/23/mvvm-light-is-cool-viewmodellocator-sucks/ for info on opening windows using MVVM
    public class MainWindowViewModel : ViewModelBase
    {
        #region Properties

        private event_detail p_Event;
        private ObservableCollection<table> p_Tables;
        private ObservableCollection<seat> p_seats;
        private ObservableCollection<guest> p_Guests;

        #endregion

        #region Command Properties

        /// <summary>
        /// ICommand to LoadEvents
        /// </summary>
        public ICommand LoadEvents { get; set; }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            this.Initialise();
        }

        #endregion

        #region Data Properties

        public event_detail Event
        {
            get
            {
                return p_Event;
            }
            set
            {
                base.RaisePropertyChangingEvent("Event");
                p_Event = value;
                base.RaisePropertyChangedEvent("Event");
            }
        }

        public ObservableCollection<table> Tables
        {
            get
            {
                return p_Tables;
            }
            set
            {
                base.RaisePropertyChangingEvent("Tables");
                p_Tables = value;
                base.RaisePropertyChangedEvent("Tables");
            }
        }

        public ObservableCollection<seat> Seats
        {
            get
            {
                return p_seats;
            }
            set
            {
                base.RaisePropertyChangingEvent("Seats");
                p_seats = value;
                base.RaisePropertyChangedEvent("Seats");
            }
        }

        public ObservableCollection<guest> Guests
        {
            get
            {
                return p_Guests;
            }
            set
            {
                base.RaisePropertyChangingEvent("Guests");
                p_Guests = value;
                base.RaisePropertyChangedEvent("Guests");
            }
        }

        #endregion

        #region Event Handlers

        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                default:
                    break;
            }
        }

        void OnPropertyChanging(object sender, System.ComponentModel.PropertyChangingEventArgs e)
        {
            switch (e.PropertyName)
            {
                default:
                    break;
            }
        }

        #endregion

        #region Private Methods

        private void Initialise()
        {
            this.PropertyChanging += OnPropertyChanging;
            this.PropertyChanged += OnPropertyChanged;
            this.LoadEvents = new LoadEventCommand(this);
        }

        #endregion
    }
}
