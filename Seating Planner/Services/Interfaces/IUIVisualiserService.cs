using System;
using Seating_Planner.Events;

namespace Seating_Planner.Services.Interfaces
{
    /// <summary>
    /// This interface defines a UI controller that will handle dialogs from viewmodels
    /// Based on code found here http://coremvvm.codeplex.com/
    /// </summary>
    public interface IUIVisualiserService
    {
        /// <summary>
        /// Registeres a type through a key
        /// </summary>
        /// <param name="key">Key for the UI dialog</param>
        /// <param name="windowType">The type implementing the dialog</param>
        void Register(string key, Type windowType);

        bool Unregister(string key);

        bool Show(string key, object state, bool setOwner,
            EventHandler<UIEventCompletedArgs> completedProc);

        /// <summary>
        /// Displays a modal dialog associated with the given key
        /// </summary>
        /// <param name="key">The key registered with the UI controller</param>
        /// <param name="state">The state to associate with the dialog</param>
        /// <returns></returns>
        bool? ShowDialog(string key, object state);
    }
}
