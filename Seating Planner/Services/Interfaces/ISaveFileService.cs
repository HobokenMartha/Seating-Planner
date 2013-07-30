using System;
using System.Windows;

namespace Seating_Planner.Services.Interfaces
{
    public interface ISaveFileService
    {
        Boolean OverwritePrompt { get; set; }
        String SavedFileName { get; set; }
        String Filter { get; set; }
        String InitialDirectory { get; set; }
        bool? ShowDialog(Window owner);
    }
}
