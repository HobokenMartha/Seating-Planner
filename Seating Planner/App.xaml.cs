using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Seating_Planner.ViewModels;
using Ninject;

namespace Seating_Planner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Create Ninject kernel instance
        private IKernel kernel = new StandardKernel();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Initialise the Ninject kernel
            kernel.Load(Assembly.GetExecutingAssembly());

            // Set up the Main Window
            var mainWindow = new MainWindow();
            var mainWindowViewModel = new MainWindowViewModel();
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }
}
