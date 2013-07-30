using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using Seating_Planner.Services.Interfaces;

namespace Seating_Planner.Services
{
    public class OpenFileService : IOpenFileService
    {
        #region Data

        private OpenFileDialog ofd = new OpenFileDialog(); 

        #endregion

        #region IOpenFileService Members

        public bool? ShowDialog(Window owner)
        {
            //Set embedded OpenFileDialog.Filter
            if (!String.IsNullOrEmpty(this.Filter))
                ofd.Filter = this.Filter;

            //Set embedded OpenFileDialog.InitialDirectory
            if (!String.IsNullOrEmpty(this.InitialDirectory))
                ofd.InitialDirectory = this.InitialDirectory;

            //return results
            return ofd.ShowDialog(owner);
        }

        public string OpenedFileName
        {
            get { return ofd.FileName; }
            set
            {
                //Do nothing
            }
        }

        public string Filter
        {
            get { return ofd.Filter; }
            set { ofd.Filter = value; }
        }

        public string InitialDirectory
        {
            get { return ofd.InitialDirectory; }
            set { ofd.InitialDirectory = value; }
        }

        #endregion
    }
}
