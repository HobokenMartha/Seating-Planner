using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Seating_Planner.ViewModels;
using Seating_Planner.Services.Interfaces;
using Seating_Planner.Services;

namespace Seating_Planner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        #region Event Handlers

        void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Subscribe to ViewModel events
            var viewModel = (MainWindowViewModel)this.DataContext;
            
            // Subscribe to the VM's CloseWindow Event
            viewModel.RequestClose += new EventHandler(Exit);
        }

        #endregion

        /// <summary>
        /// Responsible for handling the flyout menu behaviour
        /// </summary>
        private void Menu_Flyout_Click(object sender, RoutedEventArgs e)
        {
            if (rect.Visibility == System.Windows.Visibility.Collapsed)
            {
                rect.Visibility = System.Windows.Visibility.Visible;
                (sender as Button).Content = "<";
                (sender as Button).ToolTip = "Hide Menu";
            }
            else
            {
                rect.Visibility = System.Windows.Visibility.Collapsed;
                (sender as Button).Content = ">";
                (sender as Button).ToolTip = "View Menu";
            }
        }

        private void Exit(Object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Init custom window elements
        /// </summary>
        private void Initialise()
        {
            this.DataContextChanged += OnDataContextChanged;
        }
    }
}
