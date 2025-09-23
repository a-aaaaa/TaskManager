using System.Configuration;
using System.Data;
using System.Windows;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Stores;
using TaskManager.ViewModels;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private readonly DailyTaskManager _taskManager;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _taskManager = new DailyTaskManager();
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateDailyTasksViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private NewDailyTaskViewModel CreateNewDailyTaskViewModel()
        {
            return new NewDailyTaskViewModel(_taskManager, new NavigationService(_navigationStore, CreateDailyTasksViewModel));
        }

        private DailyTasksViewModel CreateDailyTasksViewModel()
        {
            return new DailyTasksViewModel(new NavigationService(_navigationStore, CreateNewDailyTaskViewModel));
        }
    }

}
