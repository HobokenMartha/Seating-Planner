using System;

namespace Seating_Planner.Events
{
    /// <summary>
    /// This is the EventArgs return value for the IUIController.Show completed event.
    /// Based on code found here http://coremvvm.codeplex.com/
    /// </summary>
    public class UIEventCompletedArgs : EventArgs
    {
        #region Public Properties

        public object State { get; set; }
        public bool? Result { get; set; }

        #endregion
    }
}
