﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Seating_Planner.Models;
using Seating_Planner.Persistence;
using Seating_Planner.ViewModels;

namespace Seating_Planner.Commands
{
    public class LoadEventCommand : ICommand
    {
        #region Fields

        private MainWindowViewModel m_ViewModel;
        DBContextFactory factory = new DBContextFactory();

        #endregion

        #region Constructor

        public LoadEventCommand(MainWindowViewModel viewModel)
        {
            this.m_ViewModel = viewModel;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            var eventRepository = new EventRepository(factory);
            var eventList = eventRepository.GetAll();

            //ObservableCollection<event_details> allEvents = eventList.to            

            //m_ViewModel.allEvents

        }

        #endregion
    }
}