using Microsoft.Data.Sqlite;
using RoutinePanel.Pages;

namespace RoutinePanel
{
    public partial class App : Application
    {
        public static SqliteConnection db;

        public App()
        {
            InitializeComponent();

            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "data.db");
            db = new SqliteConnection($"Data Source={databasePath}");
            db.Open();

            var enableForeignKeysCommand = db.CreateCommand();
            enableForeignKeysCommand.CommandText =
            @"PRAGMA foreign_keys = 1;";
            enableForeignKeysCommand.ExecuteNonQuery();

            var createTaskTableCommand = db.CreateCommand();
            createTaskTableCommand.CommandText =
            @"
                CREATE TABLE IF NOT EXISTS tasks (
                    id INTEGER PRIMARY KEY,
                    title TEXT NOT NULL,
                    description TEXT NOT NULL
                );
            ";
            createTaskTableCommand.ExecuteNonQuery();

            var createTaskCompletionTableCommand = db.CreateCommand();
            createTaskCompletionTableCommand.CommandText =
            @"
                CREATE TABLE IF NOT EXISTS task_completions (
                    id INTEGER PRIMARY KEY,
                    task_id INTEGER NOT NULL,
                    date_completed DATE DEFAULT CURRENT_DATE,
    
                    CONSTRAINT fk_tasks FOREIGN KEY(task_id) REFERENCES tasks(id) ON DELETE CASCADE
                );
            ";
            createTaskCompletionTableCommand.ExecuteNonQuery();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage());
        }

        
    }
}
