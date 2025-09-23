using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.ViewModels
{
    internal class DailyTaskViewModel : ViewModelBase
    {
        private readonly DailyTask _dailyTask;

        public string TaskName => _dailyTask.TaskName;
        public bool IsCompleted => _dailyTask.IsCompleted;

        public DailyTaskViewModel(DailyTask dailyTask)
        {
            _dailyTask = dailyTask;
        }
    }
}
