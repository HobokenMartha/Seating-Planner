using System;
using System.Windows;

namespace Seating_Planner.Services.Interfaces
{
    public interface IOpenFileService
    {
        String OpenedFileName { get; set; }
        String Filter { get; set; }
        String InitialDirectory { get; set; }
        bool? ShowDialog(Window owner);
    }
}
