using RoutinePanel.Components.Global;
using RoutinePanel.Lib;

namespace RoutinePanel.Components.TaskCompletionPage
{
    internal class TaskRepresentation : Grid
    {
        public TaskModel TaskDetails { get; set; }

        public TaskRepresentation(TaskModel taskDetails)
        {
            Padding = 8;
            TaskDetails = taskDetails;

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

            if (taskDetails.completed)
            {
                Label titleLabel = new AppLabel
                {
                    Text = TaskDetails.title,
                    FontSize = 15
                };

                this.Add(titleLabel, 0, 0);
                this.Add(new AppLabel
                {
                    Text = TaskDetails.description,
                    FontSize = 11
                }, 0, 1);
                this.Add(new AppButton
                {
                    Text = "Oznacz jako nieukończone",
                    OnClick = (_, _) =>
                    {
                        int? completionId = TaskModel.GetCompletionId(TaskDetails);

                        if (completionId == null)
                        {
                            return;
                        }

                        TaskCompletionModel.Delete((int)completionId);
                    }
                }, 0, 2);
            }
            else
            {
                Label titleLabel = new AppLabel
                {
                    Text = TaskDetails.title,
                    FontSize = 15
                };

                this.Add(titleLabel, 0, 0);
                this.Add(new AppLabel
                {
                    Text = TaskDetails.description,
                    FontSize = 11
                }, 0, 1);
                this.Add(new AppButton
                {
                    Text = "Oznacz jako ukończone",
                    OnClick = (_, _) =>
                    {
                        TaskCompletionModel.Insert(TaskDetails.id);
                    }
                }, 0, 2);
            }
        }
    }
}