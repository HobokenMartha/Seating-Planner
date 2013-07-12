using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seating_Planner.Models;
using Seating_Planner.Commands;

namespace Seating_Planner.ViewModels
{
    public class CreateEventViewModel : ViewModelBase
    {
        #region Properties

        #endregion

        #region Commands

        #endregion

        #region Event Handlers

        //TODO Add Properties
        void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                default:
                    break;
            }
        }

        //TODO: Add Properties
        void OnPropertyChanging(object sender, System.ComponentModel.PropertyChangingEventArgs e)
        {
            switch (e.PropertyName)
            {
                default:
                    break;
            }
        }

        #endregion

        #region Contructors

        public CreateEventViewModel()
        {
            this.Initialise();   
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void Initialise()
        {
            this.PropertyChanging += OnPropertyChanging;
            this.PropertyChanged += OnPropertyChanged;
        }

        #endregion
    }
}
