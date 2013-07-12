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
    /// Interaction logic for CreateEventWindow.xaml
    /// </summary>
    public partial class CreateEventWindow : Window
    {
        public CreateEventWindow()
        {
            InitializeComponent();
            Initialise();
        }

        #region Event Handlers

        void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = (CreateEventViewModel)this.DataContext;
        }

        #endregion

        private void Initialise()
        {
            this.DataContextChanged += OnDataContextChanged;
        }
    }
}
