using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.DTOs
{
    internal class DailyTaskDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string TaskName { get; set; }
    }
}
