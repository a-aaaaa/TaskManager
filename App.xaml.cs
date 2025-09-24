using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using TaskManager.DbContexts;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Services.DailyTaskCreators;
using TaskManager.Services.DailyTaskProviders;
using TaskManager.Stores;
using TaskManager.ViewModels;

namespace TaskManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private const string CONNECTION_STRING = "Data Source=taskmanager.db";

        private readonly TaskManagerDbContextFactory _taskManagerDbContextFactory;
        private readonly DailyTaskManager _taskManager;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _taskManagerDbContextFactory = new TaskManagerDbContextFactory(CONNECTION_STRING);
            IDailyTaskProvider dailyTaskProvider = new DatabaseDailyTaskProvider(_taskManagerDbContextFactory);
            IDailyTaskCreator dailyTaskCreator = new DatabaseDailyTaskCreator(_taskManagerDbContextFactory);
            _taskManager = new DailyTaskManager(dailyTaskProvider, dailyTaskCreator);
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (TaskManagerDbContext dbContext = _taskManagerDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

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
            return DailyTasksViewModel.LoadViewModel(_taskManager, new NavigationService(_navigationStore, CreateNewDailyTaskViewModel));
        }
    }

}
