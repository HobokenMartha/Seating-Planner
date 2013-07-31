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
using Seating_Planner.Persistence;
using Seating_Planner.Commands;
using Seating_Planner.Services;
using Seating_Planner.Services.Interfaces;
using Seating_Planner.Views;
using System.Diagnostics;

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
        private ObservableCollection<event_detail> p_Events = new ObservableCollection<event_detail>();
        private IUIVisualiserService uiVisualService = null;

        #endregion

        #region Command Properties

        private DelegateCommand openEventCommand;
        private DelegateCommand loadEventsCommand;

        /// <summary>
        /// DelegateCommand to LoadEvents
        /// </summary>
        public DelegateCommand LoadEventsCommand
        {
            get
            {
                if (loadEventsCommand == null)
                {
                    loadEventsCommand = new DelegateCommand(LoadEvents);
                }

                return loadEventsCommand;
            }
        }

        private void LoadEvents()
        {
            DBContextFactory factory = new DBContextFactory();
            var eventRepository = new EventRepository(factory);
            IEnumerable<event_detail> ed = eventRepository.GetAll();

            foreach (event_detail e in ed)
            {
                this.Events.Add(e);
            }
        }

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

        public ObservableCollection<event_detail> Events
        {
            get
            {
                return p_Events;
            }
            private set
            {
                base.RaisePropertyChangingEvent("Events");
                p_Events = value;
                base.RaisePropertyChangedEvent("Events");
            }
        }

        #endregion

        #region OpenEventWindow
        public DelegateCommand OpenEventCommand
        {
            get
            {
                if (openEventCommand == null)
                {
                    openEventCommand = new DelegateCommand(OpenEventWindow);
                }

                return openEventCommand;
            }
        }

        private void OpenEventWindow()
        {
            uiVisualService.Show("LoadEventWindow", this, true, null);
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
            ViewModelBase.ServiceProvider.RegisterService<IUIVisualiserService>(new UIVisualiserService());
            uiVisualService = GetService<IUIVisualiserService>();
            uiVisualService.Register("LoadEventWindow", typeof(LoadEvent));
        }

        #endregion
    }
}
