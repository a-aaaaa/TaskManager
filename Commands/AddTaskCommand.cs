using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.ViewModels;

namespace TaskManager.Commands
{
    class AddTaskCommand : CommandBase
    {
        private readonly NewDailyTaskViewModel _newDailyTaskViewModel;
        private readonly DailyTaskManager _taskManager;
        private readonly NavigationService _dailyTasksViewNavigationService;

        public AddTaskCommand(NewDailyTaskViewModel newDailyTaskViewModel,
            DailyTaskManager taskManager,
            NavigationService dailyTasksViewNavigationService)
        {
            _newDailyTaskViewModel = newDailyTaskViewModel;
            _taskManager = taskManager;
            _dailyTasksViewNavigationService = dailyTasksViewNavigationService;

            _newDailyTaskViewModel.PropertyChanged += _newDailyTaskViewModel_PropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_newDailyTaskViewModel.TaskName) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            _taskManager.CreateNewTask(_newDailyTaskViewModel.TaskName);

            _dailyTasksViewNavigationService.Navigate();
        }
        private void _newDailyTaskViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(NewDailyTaskViewModel.TaskName))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
