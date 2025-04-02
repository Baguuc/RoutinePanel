using RoutinePanel.Lib;

namespace RoutinePanel.Components
{
    internal class TaskCompletion : Grid
    {
        public TaskModel TaskDetails { get; set; }
        public bool Completed { get; set; }

        public TaskCompletion(TaskModel taskDetails, bool completed, Action RefreshTaskList)
        {
            Padding = 8;
            TaskDetails = taskDetails;
            Completed = completed;

            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition()
            };
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition(),
                new RowDefinition(),
                new RowDefinition()
            };
            RowSpacing = 4;

            WidthRequest = 200;
            
            if(Completed)
            {
                Label titleLabel = new AppLabel
                {
                    Text = TaskDetails.Title,
                    FontSize = 15
                };

                this.Add(titleLabel, 0, 0);
                this.Add(new AppLabel
                {
                    Text = TaskDetails.Description,
                    FontSize = 11
                }, 0, 1);
                this.Add(new AppButton
                {
                    Text = "Oznacz jako nieukoñczone",
                    OnClick = (_, _) =>
                    {
                        int completionId = App.db.Table<TaskCompletionModel>()
                            .Where(completion => completion.TaskId == TaskDetails.Id)
                            .First()
                            .Id;
                        
                        App.db.Delete(new TaskCompletionModel
                        {
                            Id = completionId,
                            TaskId = TaskDetails.Id
                        });
                        RefreshTaskList();
                    }
                }, 0, 2);
            }
            else
            {
                Label titleLabel = new AppLabel
                {
                    Text = TaskDetails.Title,
                    FontSize = 15
                };

                this.Add(titleLabel, 0, 0);
                this.Add(new AppLabel
                {
                    Text = TaskDetails.Description,
                    FontSize = 11
                }, 0, 1);
                this.Add(new AppButton
                {
                    Text = "Oznacz jako ukoñczone",
                    OnClick = (_, _) =>
                    {
                        App.db.Insert(new TaskCompletionModel
                        {
                            TaskId = TaskDetails.Id
                        });
                        RefreshTaskList();
                    }
                }, 0, 2);
            }
        }
    }
}
