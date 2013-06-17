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
    public class MainWindowViewModel : ViewModelBase
    {
        private event_details p_CurrentEvent;
        private ObservableCollection<table> p_Tables;

        public static readonly DependencyProperty FlyoutButtonProperty =
            DependencyProperty.RegisterAttached("FlyoutButton", typeof(Button), typeof(MainWindowViewModel), new FrameworkPropertyMetadata(OnFlyoutButtonClick));

        private static Rectangle r = null;

        public static void OnFlyoutButtonClick(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            r = obj as Rectangle;
        }

        private DelegateCommand flyoutCommand;
        public ICommand FlyoutCommand
        {
            get
            {
                if (flyoutCommand == null)
                    flyoutCommand = new DelegateCommand(Flyout);

                return flyoutCommand;
            }
        }

        public MainWindowViewModel()
        {

        }

        public event_details currentEvent
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
    }
}
