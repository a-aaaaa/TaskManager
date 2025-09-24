using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.DTOs;
using TaskManager.Models;

namespace TaskManager.DbContexts
{
    internal class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions options) : base(options) { }

        public DbSet<DailyTaskDTO> DailyTasks { get; set; } 
    }
}
