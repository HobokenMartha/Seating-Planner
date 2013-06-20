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

        private event_detail p_CurrentEvent;
        private ObservableCollection<event_detail> p_AllEvents;
        private ObservableCollection<table> p_Tables;

        public static readonly DependencyProperty FlyoutButtonProperty =
            DependencyProperty.RegisterAttached("FlyoutButton", typeof(Button), typeof(MainWindowViewModel), new FrameworkPropertyMetadata(OnFlyoutButtonClick));

        private DelegateCommand flyoutCommand;

        private static Rectangle r = null;

        #endregion

        public static void OnFlyoutButtonClick(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            r = obj as Rectangle;
        }

        #region Command Properties

        public ICommand LoadEvents { get; set; }

        #endregion

        public ICommand FlyoutCommand
        {
            get
            {
                if (flyoutCommand == null)
                    flyoutCommand = new DelegateCommand(Flyout);

                return flyoutCommand;
            }
        }

        #region Constructors

        public MainWindowViewModel()
        {
            this.Initialise();
        }

        #endregion

        #region Data Properties

        public ObservableCollection<event_detail> allEvents
        {
            get
            {
                return p_AllEvents;
            }

            set
            {
                base.RaisePropertyChangingEvent("allEvents");
                p_AllEvents = value;
                base.RaisePropertyChangedEvent("allEvents");
            }
        }

        public event_detail currentEvent
        {
            get
            {
                return p_CurrentEvent;
            }
            set
            {
                base.RaisePropertyChangingEvent("currentEvent");
                p_CurrentEvent = value;
                base.RaisePropertyChangedEvent("currentEvent");
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

        private void Flyout()
        {
            // Implement the flyout menu functionality
            if (r != null)
            {
                
                if (r.Visibility == System.Windows.Visibility.Collapsed)
                {
                    r.Visibility = System.Windows.Visibility.Visible;
                    //(sender as Button).Content = "<";
                }
                else
                {
                    r.Visibility = System.Windows.Visibility.Collapsed;
                    //(sender as Button).Content = ">";
                }
            }
        }

        private void Initialise()
        {
            this.PropertyChanging += OnPropertyChanging;
            this.PropertyChanged += OnPropertyChanged;
            this.LoadEvents = new LoadEventCommand(this);
        }
    }
}
