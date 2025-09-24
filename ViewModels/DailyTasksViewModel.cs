using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    internal class DailyTasksViewModel : ViewModelBase
    {
        private readonly ObservableCollection<DailyTaskViewModel> _dailyTasks;

        public ObservableCollection<DailyTaskViewModel> DailyTasks => _dailyTasks;
        public ICommand LoadDailyTasksCommand { get; }
        public ICommand NewTaskCommand { get; }

        public DailyTasksViewModel(DailyTaskManager taskManager, NavigationService newDailyTaskViewNavigationService)
        {
            _dailyTasks = new ObservableCollection<DailyTaskViewModel>();

            LoadDailyTasksCommand = new LoadDailyTasksCommand(this, taskManager);
            NewTaskCommand = new NavigateCommand(newDailyTaskViewNavigationService);
        }

        public static DailyTasksViewModel LoadViewModel(DailyTaskManager taskManager, NavigationService newDailyTaskViewNavigationService)
        {
            DailyTasksViewModel viewModel = new DailyTasksViewModel(taskManager, newDailyTaskViewNavigationService);

            viewModel.LoadDailyTasksCommand.Execute(null);

            return viewModel;
        }

        public void UpdateDailyTasks(IEnumerable<DailyTask> dailyTasks)
        {
            _dailyTasks.Clear();

            foreach (DailyTask dailyTask in dailyTasks)
            {
                DailyTaskViewModel dailyTaskViewModel = new DailyTaskViewModel(dailyTask);
                _dailyTasks.Add(dailyTaskViewModel);
            }
        }
    }
}
