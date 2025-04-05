using RoutinePanel.State;

namespace RoutinePanel.Lib
{
    internal class CompletionRate
    {
        public DateTime date { get; }
        public int completedCount { get; }
        public int totalCount { get;}
        public int completionPercentage { get; }

        public CompletionRate(DateTime date, int completed_count, int total_completed, int completion_percentage)
        {
            this.date = date;
            this.completedCount = completed_count;
            this.totalCount = total_completed;
            this.completionPercentage = completion_percentage;
        }
    }
    internal class TaskCompletionModel
    {
        public int id { get; set; }
        public int taskId { get; set; }

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

        public static List<CompletionRate> GetCompletionRatesForLast7Days()
        {
            var command = App.db.CreateCommand();
            command.CommandText = @"SELECT 
	            s.date,
	            s.completed_count,
	            s.total_count,
	            CAST(CAST(s.completed_count as REAL) / CAST(s.total_count as REAL) * 100 as INTEGER) AS completion_percentage
            FROM (
	            SELECT 
		            date_completed AS date,
		            COUNT(*) AS completed_count,
		            (SELECT COUNT(*) FROM tasks) AS total_count
	            FROM 
		            task_completions 
	            GROUP BY date_completed
            ) AS s
            WHERE 
	            s.date >= DATE(DATE('now'), '-7 days')
	            AND
	            s.date <= DATE('now')
            ORDER BY date ASC
            LIMIT 7;";

            List<CompletionRate> rates = new List<CompletionRate>();

            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                rates.Add(new CompletionRate(
                    reader.GetDateTime(0),
                    reader.GetInt32(1),
                    reader.GetInt32(2),
                    reader.GetInt32(3)
                ));
            }

            for(int i = 0; i < 7 - rates.Count; i++)
            {
                rates = rates.Prepend(new CompletionRate(DateTime.Now, 0, 0, 0))
                    .ToList();
            }

            return rates;
        }

        public static CompletionRate GetTodaysCompletionRate()
        {
            var command = App.db.CreateCommand();
            command.CommandText = @"SELECT 
	            s.date,
	            s.completed_count,
	            s.total_count,
	            CAST(CAST(s.completed_count as REAL) / CAST(s.total_count as REAL) * 100 as INTEGER) AS completion_percentage
            FROM (
	            SELECT 
		            date_completed AS date,
		            COUNT(*) AS completed_count,
		            (SELECT COUNT(*) FROM tasks) AS total_count
	            FROM 
		            task_completions 
	            GROUP BY date_completed
            ) AS s
            WHERE 
                s.date = DATE('now');
            ";

            var reader = command.ExecuteReader();
            if(!reader.Read())
            {
                // there is no completions today but there still are tasks to fill in the total count with
                return new CompletionRate(DateTime.Now, 0, TaskModel.SelectAll().Count, 0);
            }

            return new CompletionRate(
                reader.GetDateTime(0),
                reader.GetInt32(1),
                reader.GetInt32(2),
                reader.GetInt32(3)
            );
        }
    }
}
