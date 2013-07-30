using System;

namespace Seating_Planner.Events
{
    public class CloseRequestEventArgs : EventArgs
    {
        public bool? Result { get; private set; }
        internal CloseRequestEventArgs(bool? result)
        {
            Result = result;
        }
    }
}
