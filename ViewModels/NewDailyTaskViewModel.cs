using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Commands;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Stores;

namespace TaskManager.ViewModels
{
    internal class NewDailyTaskViewModel : ViewModelBase
    {
        private string _taskName;

        public string TaskName
        {
            get
            {
                return _taskName;
            }
            set
            {
                _taskName = value;
                OnPropertyChanged(nameof(TaskName));
            }
        }

        public ICommand AddTaskCommand { get; }

        public ICommand CancelCommand { get; }

        public NewDailyTaskViewModel(DailyTaskManager taskManager,
            NavigationService dailyTasksViewNavigationService)
        {
            AddTaskCommand = new AddTaskCommand(this, taskManager, dailyTasksViewNavigationService);
            CancelCommand = new NavigateCommand(dailyTasksViewNavigationService);
        }
    }
}
