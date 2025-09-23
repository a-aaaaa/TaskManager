using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Commands;
using TaskManager.Services;
using TaskManager.Stores;

namespace TaskManager.ViewModels
{
    internal class DailyTasksViewModel : ViewModelBase
    {
        private readonly ObservableCollection<DailyTaskViewModel> _dailyTasks;

        public ObservableCollection<DailyTaskViewModel> DailyTasks => _dailyTasks;
        public ICommand NewTaskCommand { get; }

        public DailyTasksViewModel(NavigationService newDailyTaskViewNavigationService)
        {
            _dailyTasks = new ObservableCollection<DailyTaskViewModel>();

            NewTaskCommand = new NavigateCommand(newDailyTaskViewNavigationService);

            _dailyTasks.Add(new DailyTaskViewModel(new Models.DailyTask("task1")));
            _dailyTasks.Add(new DailyTaskViewModel(new Models.DailyTask("task2")));
        }
    }
}
