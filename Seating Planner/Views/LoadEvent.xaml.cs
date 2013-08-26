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
using System.Windows.Shapes;
using Seating_Planner.ViewModels;

namespace Seating_Planner.Views
{
    /// <summary>
    /// Interaction logic for LoadEvent.xaml
    /// </summary>
    public partial class LoadEvent : Window
    {
        public LoadEvent()
        {
            InitializeComponent();
            Initialise();
        }

        #region Event Handlers

        void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (MainWindowViewModel)this.DataContext;
            
            // Subscribe to the VM's CloseWindow Event
            viewModel.RequestClose += new EventHandler(CloseWindow);
        }

        #endregion

        #region Private Methods

        private void Initialise()
        {
            this.DataContextChanged += OnDataContextChanged;
        }

        /// <summary>
        /// Handles double clicking list items to open projects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void listItemDoubleClick(object sender, MouseEventArgs args)
        {
            var viewModel = (MainWindowViewModel)this.DataContext;
            if (viewModel.OpenSingleEventCommand.CanExecute())
                viewModel.OpenSingleEventCommand.Execute();
        }

        #endregion

        /// <summary>
        /// Handles the closing of the Window
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void CloseWindow(Object source, EventArgs args)
        {
            this.Close();
        }
    }
}
