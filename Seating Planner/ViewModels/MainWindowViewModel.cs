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

namespace Seating_Planner.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Properties

        private bool p_EventLoaded = false;
        // MainWindow hooks into this to display the loaded event
        private bool p_DoEventLoad = false;
        private event_detail p_Event;
        private string p_WindowTitle;
        private ObservableCollection<table> p_Tables;
        private ObservableCollection<seat> p_Seats;
        private ObservableCollection<guest> p_Guests;
        private ObservableCollection<event_detail> p_Events = new ObservableCollection<event_detail>();
        private IUIVisualiserService uiVisualService = null;

        #endregion

        // Public EventHandler for Views to subscribe to for closing windows
        public EventHandler RequestClose;

        #region Command Properties

        private DelegateCommand openEventCommand;
        private DelegateCommand loadEventsCommand;
        private DelegateCommand openSingleEventCommand;
        private DelegateCommand closeOpenEventCommandWindow;
        
        // Public command to handle closing windows
        public ICommand ExitCommand { get; set; }

        #region Load Events Command
        /// <summary>
        /// DelegateCommand to Load Events
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
            this.Events.Clear();
            DBContextFactory factory = new DBContextFactory();
            var eventRepository = new EventRepository(factory);
            IEnumerable<event_detail> ed = eventRepository.GetAll();

            foreach (event_detail e in ed)
            {
                this.Events.Add(e);
            }
        }

        #endregion

        #region OpenEventWindow

        /// <summary>
        /// Delegate Command to handle opening the load event window
        /// </summary>
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
            // Initialise the Events Observable Collection
            LoadEvents();

            // Open the Load Event Window
            uiVisualService.Show("LoadEventWindow", this, true, null);
        }

        #endregion

        #region Open a Single Event Command

        public DelegateCommand OpenSingleEventCommand
        {
            get
            {
                if (openSingleEventCommand == null)
                {
                    openSingleEventCommand = new DelegateCommand(OpenEvent);
                }

                return openSingleEventCommand;
            }
        }

        private void OpenEvent()
        {
            foreach (table t in this.p_Event.tables)
            {
                this.p_Tables.Add(t);
            }

            foreach (guest g in this.p_Event.guests)
            {
                this.p_Guests.Add(g);
            }

            foreach (seat s in this.p_Event.seats)
            {
                this.p_Seats.Add(s);
            }

            // Indicate that we've loaded an Event.
            DoEventLoad = true;

            // Set the main window's title bar.
            WindowTitle = p_Event.event_name;

            // Close the popup window
            CloseWindow();
        }

        #endregion

        public DelegateCommand CloseOpenEventCommand
        {
            get
            {
                if (closeOpenEventCommandWindow == null)
                {
                    closeOpenEventCommandWindow = new DelegateCommand(CancelOpenEventWindow);
                }

                return closeOpenEventCommandWindow;
            }
        }

        private void CancelOpenEventWindow()
        {
            uiVisualService.Unregister("LoadEventWindow");
        }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            this.Initialise();
        }

        #endregion

        #region Data Properties

        /// <summary>
        /// An observable data property to indicate whether or not p_Event holds an event_detail object
        /// </summary>
        public bool EventLoaded 
        {
            get
            {
                return this.p_EventLoaded;
            }
            set
            {
                base.RaisePropertyChangingEvent("EventLoaded");
                this.p_EventLoaded = value;
                base.RaisePropertyChangedEvent("EventLoaded");
            }
        }

        public bool DoEventLoad
        {
            get
            {
                return this.p_DoEventLoad;
            }
            set
            {
                base.RaisePropertyChangingEvent("DoEventLoad");
                this.p_DoEventLoad = value;
                base.RaisePropertyChangedEvent("DoEventLoad");
            }
        }

        /// <summary>
        /// The currently loaded event
        /// </summary>
        public event_detail Event
        {
            get
            {
                return p_Event;
            }
            set
            {
                if (value != null)
                {
                    base.RaisePropertyChangingEvent("Event");
                    p_Event = value;
                    base.RaisePropertyChangedEvent("Event");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string WindowTitle
        {
            get
            {
                if (this.p_Event == null)
                {
                    p_WindowTitle = "Seating Planner";
                    return p_WindowTitle;
                }
                else
                {
                    p_WindowTitle = p_Event.event_name + " - Seating Planner";
                    return p_WindowTitle;
                }
            }
            set
            {
                if (this.p_Event == null)
                {
                    p_WindowTitle = "Seating Planner";
                }
                else
                {
                    p_WindowTitle = p_Event.event_name + " - Seating Planner";
                }
                base.RaisePropertyChangedEvent("WindowTitle");
            }
        }

        /// <summary>
        /// The tables associated with a particular event
        /// </summary>
        public ObservableCollection<table> Tables
        {
            get
            {
                return p_Tables;
            }
            set
            {
                this.p_Tables.Clear();
                base.RaisePropertyChangingEvent("Tables");
                p_Tables = value;
                base.RaisePropertyChangedEvent("Tables");
            }
        }

        /// <summary>
        /// All seats allocated to a particular event
        /// </summary>
        public ObservableCollection<seat> Seats
        {
            get
            {
                return p_Seats;
            }
            set
            {
                this.p_Seats.Clear();
                base.RaisePropertyChangingEvent("Seats");
                p_Seats = value;
                base.RaisePropertyChangedEvent("Seats");
            }
        }

        /// <summary>
        /// Guests associated with a particular event
        /// </summary>
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

        /// <summary>
        /// All events
        /// </summary>
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

        #region Event Handlers
        
        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Event":
                    if (p_Event != null)
                        EventLoaded = true;
                    else
                        EventLoaded = false;
                    break;
                case "DoEventLoad":
                    break;
                case "WindowTitle":
                    break;
                default:
                    break;
            }
        }

        void OnPropertyChanging(object sender, System.ComponentModel.PropertyChangingEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Event":
                    break;
                case "DoEventLoad":
                    break;
                default:
                    break;
            }
        }
     
        #endregion

        #region Private Methods

        private void CloseWindow()
        {
            EventHandler handler = this.RequestClose;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void Initialise()
        {
            this.PropertyChanging += OnPropertyChanging;
            this.PropertyChanged += OnPropertyChanged;
            ViewModelBase.ServiceProvider.RegisterService<IUIVisualiserService>(new UIVisualiserService());
            uiVisualService = GetService<IUIVisualiserService>();
            uiVisualService.Register("LoadEventWindow", typeof(LoadEvent));
            ExitCommand = new DelegateCommand(CloseWindow);
        }

        #endregion
    }
}
