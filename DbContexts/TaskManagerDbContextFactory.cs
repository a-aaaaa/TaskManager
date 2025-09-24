using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.DbContexts
{
    internal class TaskManagerDbContextFactory
    {
        private readonly string _connectionString;

        public TaskManagerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public TaskManagerDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new TaskManagerDbContext(options);
        }
    }
}
