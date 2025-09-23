using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskManager.ViewModels
{
    internal class NewDailyTaskViewModel : ViewModelBase
    {
        private string _taskName;

        public string TaskName
        {
            get
            {
                return _taskName;
            }
            set
            {
                _taskName = value;
                OnPropertyChanged(nameof(TaskName));
            }
        }

        public ICommand AddTaskCommand { get; }

        public ICommand CancelCommand { get; }
    }
}
