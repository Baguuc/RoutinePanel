using RoutinePanel.State;

namespace RoutinePanel.Lib
{
    internal class TaskCompletionModel
    {
        public int id { get; set; }
        public int taskId { get; set; }
        public DateTime date { get; set; }

        public TaskCompletionModel(int id, int taskId)
        {
            this.taskId = taskId;
        }

        public static void Insert(int taskId)
        {
            var command = App.db.CreateCommand();
            command.CommandText = "INSERT INTO task_completions (task_id) VALUES ($id);";
            command.Parameters.AddWithValue("$id", taskId);

            command.ExecuteNonQuery();

            StateManagers.TaskStateManager.Update(TaskModel.SelectAll());
        }

        public static void Delete(int id)
        {
            var command = App.db.CreateCommand();
            command.CommandText = "DELETE FROM task_completions WHERE id = $id;";
            command.Parameters.AddWithValue("$id", id);

            command.ExecuteNonQuery();

            StateManagers.TaskStateManager.Update(TaskModel.SelectAll());
        }
    }
}
