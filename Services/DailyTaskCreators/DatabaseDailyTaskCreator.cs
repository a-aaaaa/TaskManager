using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DbContexts;
using TaskManager.DTOs;
using TaskManager.Models;

namespace TaskManager.Services.DailyTaskCreators
{
    internal class DatabaseDailyTaskCreator : IDailyTaskCreator
    {
        private readonly TaskManagerDbContextFactory _dbContextFactory;

        public DatabaseDailyTaskCreator(TaskManagerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateDailyTask(DailyTask dailyTask)
        {
            using (TaskManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                DailyTaskDTO dailyTaskDTO = ToDailyTaskDTO(dailyTask);

                context.DailyTasks.Add(dailyTaskDTO);
                await context.SaveChangesAsync();
            }
        }

        private DailyTaskDTO ToDailyTaskDTO(DailyTask dailyTask)
        {
            return new DailyTaskDTO()
            {
                TaskName = dailyTask.TaskName
            };
        }
    }
}
