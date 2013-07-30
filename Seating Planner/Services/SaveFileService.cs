using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using Seating_Planner.Services.Interfaces;

namespace Seating_Planner.Services
{
    public class SaveFileService : ISaveFileService
    {
        #region Data

        /// <summary>
        /// Embedded SaveFileDialog to pass back correctly selected
        /// values to ViewModel
        /// </summary>
        private SaveFileDialog sfd = new SaveFileDialog();

        #endregion

        #region ISaveFileService Members

        public bool OverwritePrompt
        {
            get { return sfd.OverwritePrompt; }
            set { sfd.OverwritePrompt = value; }
        }

        public string SavedFileName
        {
            get { return sfd.FileName; }
            set
            {
                //Do nothing
            }
        }

        public string Filter
        {
            get { return sfd.Filter; }
            set { sfd.Filter = value; }
        }

        public string InitialDirectory
        {
            get { return sfd.InitialDirectory; }
            set { sfd.InitialDirectory = value; }
        }

        public bool? ShowDialog(Window owner)
        {
            //Set embedded SaveFileDialog.Filter
            if (!String.IsNullOrEmpty(this.Filter))
                sfd.Filter = this.Filter;

            //Set embedded SaveFileDialog.InitialDirectory
            if (!String.IsNullOrEmpty(this.InitialDirectory))
                sfd.InitialDirectory = this.InitialDirectory;

            //Set embedded SaveFileDialog.OverwritePrompt
            sfd.OverwritePrompt = this.OverwritePrompt;

            //return results
            return sfd.ShowDialog(owner);
        }

        #endregion
    }
}
