using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Services.DailyTaskCreators;
using TaskManager.Services.DailyTaskProviders;

namespace TaskManager.Models
{
    public class DailyTaskManager
    {
        private readonly IDailyTaskProvider _dailyTaskProvider;
        private readonly IDailyTaskCreator _dailyTaskCreator;

        public DailyTaskManager(IDailyTaskProvider dailyTaskProvider, IDailyTaskCreator dailyTaskCreator)
        {
            _dailyTaskProvider = dailyTaskProvider;
            _dailyTaskCreator = dailyTaskCreator;
        }

        public async Task CreateNewTask(string taskName)
        {
            await _dailyTaskCreator.CreateDailyTask(new DailyTask(taskName));
        }

        public async Task<IEnumerable<DailyTask>> GetAllTasks()
        {
            return await _dailyTaskProvider.GetAllDailyTasks();
        }
    }
}
