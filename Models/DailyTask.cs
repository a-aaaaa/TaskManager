using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class DailyTask
    {
        public string TaskName { get; }
        public bool IsCompleted { get; set; }
        
        public DailyTask(string taskName)
        {
            TaskName = taskName;
            IsCompleted = false;
        }
    }
}
