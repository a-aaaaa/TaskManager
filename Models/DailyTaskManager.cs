using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class DailyTaskManager
    {
        private readonly List<DailyTask> _dailyTasks;

        public DailyTaskManager()
        {
            _dailyTasks = new List<DailyTask>();
        }

        public void CreateNewTask(string taskName)
        {
            _dailyTasks.Add(new DailyTask(taskName));
        }

        public IEnumerable<DailyTask> GetAllTasks()
        {
            return _dailyTasks;
        }
    }
}
