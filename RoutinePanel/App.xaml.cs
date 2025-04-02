
using RoutinePanel.Lib;
using RoutinePanel.Pages;
using SQLite;

namespace RoutinePanel
{
    public partial class App : Application
    {
        public static SQLiteConnection db;

        public App()
        {
            InitializeComponent();

            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "data.db");
            db = new SQLiteConnection(databasePath);
            
            db.CreateTable<TaskModel>();
            db.CreateTable<TaskCompletionModel>();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage());
        }
    }
}
