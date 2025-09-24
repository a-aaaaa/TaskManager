using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Commands
{
    internal class LoadDailyTasksCommand : AsyncCommandBase
    {
        private readonly DailyTasksViewModel _viewModel;
        private readonly DailyTaskManager _dailyTaskManager;

        public LoadDailyTasksCommand(DailyTasksViewModel viewModel, DailyTaskManager dailyTaskManager)
        {
            _viewModel = viewModel;
            _dailyTaskManager = dailyTaskManager;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<DailyTask> dailyTasks = await _dailyTaskManager.GetAllTasks();

            _viewModel.UpdateDailyTasks(dailyTasks);
        }
    }
}
