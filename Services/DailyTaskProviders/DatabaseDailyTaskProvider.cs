using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.DbContexts;
using TaskManager.DTOs;
using TaskManager.Models;

namespace TaskManager.Services.DailyTaskProviders
{
    internal class DatabaseDailyTaskProvider : IDailyTaskProvider
    {
        private readonly TaskManagerDbContextFactory _dbContextFactory;

        public DatabaseDailyTaskProvider(TaskManagerDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<DailyTask>> GetAllDailyTasks()
        {
            using (TaskManagerDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<DailyTaskDTO> dailyTaskDTOs = await context.DailyTasks.ToListAsync();

                return dailyTaskDTOs.Select(t => ToDailyTask(t));
            }
        }

        private static DailyTask ToDailyTask(DailyTaskDTO dto)
        {
            return new DailyTask(dto.TaskName);
        }
    }
}
