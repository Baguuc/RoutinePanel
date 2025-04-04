using RoutinePanel.State;

namespace RoutinePanel.Lib
{
    public class TaskModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool completed { get; set; }

        public TaskModel(string title, string description)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.completed = false;
        }

        public TaskModel(int id, string title, string description)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.completed = false;
        }

        public TaskModel(int id, string title, string description, bool completed)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.completed = completed;
        }

        public static void Insert(TaskModel task)
        {
            var command = App.db.CreateCommand();
            command.CommandText = "INSERT INTO tasks (title, description) VALUES ($title, $description);";
            command.Parameters.AddWithValue("$title", task.title);
            command.Parameters.AddWithValue("description", task.description);

            command.ExecuteNonQuery();

            StateManagers.TaskStateManager.Update(TaskModel.SelectAll());
        }

        public static void Delete(int id)
        {
            var command = App.db.CreateCommand();
            command.CommandText = "DELETE FROM tasks WHERE id = $id;";
            command.Parameters.AddWithValue("$id", id);

            command.ExecuteNonQuery();

            StateManagers.TaskStateManager.Update(TaskModel.SelectAll());
        }

        public static List<TaskModel> SelectAll()
        {
            List<TaskModel> tasks = SelectAllRaw().Select((task) =>
            {
                var command = App.db.CreateCommand();
                command.CommandText = "SELECT tc.date_completed FROM task_completions tc WHERE date_completed == DATE('now') AND tc.task_id = $task_id;";
                command.Parameters.AddWithValue("$task_id", task.id);

                // returns true if there is no rows left
                // and since it's the first row it will signal a empty result set
                bool completed = command.ExecuteReader().Read();

                return new TaskModel(task.id, task.title, task.description, completed);
            })
            .ToList();

            return tasks;
        }

        private static List<TaskModel> SelectAllRaw()
        {
            List<TaskModel> tasks = new List<TaskModel>();

            var command = App.db.CreateCommand();
            command.CommandText = "SELECT t.id, t.title, t.description FROM tasks t;";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    tasks.Add(new TaskModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
            }

            return tasks;
        }

        public static TaskModel? SelectOne(int id)
        {
            var command = App.db.CreateCommand();
            command.CommandText = "SELECT tc.date_completed FROM task_completions tc WHERE date_completed == DATE('now') AND tc.task_id = $id";
            command.Parameters.AddWithValue("$id", id);

            // returns true if there is no rows left
            // and since it's the first row it will signal a empty result set
            bool completed = command.ExecuteReader().Read();

            TaskModel? task = SelectOneRaw(id);

            if(task == null)
            {
                return null;
            }

            return new TaskModel(task.id, task.title, task.description, completed);
        }

        private static TaskModel? SelectOneRaw(int id)
        {
            var command = App.db.CreateCommand();
            command.CommandText = "SELECT t.id, t.title, t.description FROM tasks t AND id = $id;";
            command.Parameters.AddWithValue("$id", id);

            var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            TaskModel task = new TaskModel(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

            return task;
        }

        public static int? GetCompletionId(TaskModel task)
        {
            var command = App.db.CreateCommand();
            command.CommandText = "SELECT tc.id FROM task_completions tc WHERE task_id = $task_id;";
            command.Parameters.AddWithValue("$task_id", task.id);

            var reader = command.ExecuteReader();

            if (!reader.Read())
            {
                return null;
            }

            int id = reader.GetInt32(0);

            return id;
        }
    }
}
