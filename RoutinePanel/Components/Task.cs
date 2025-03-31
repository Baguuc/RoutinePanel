using RoutinePanel.Lib;

namespace RoutinePanel.Components
{
    internal class Task : Grid
    {
        public TaskModel Details { get; set; }

        public Task(TaskModel details, Action RefreshTaskList)
        {
            Padding = 8;
            Details = details;

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
            Label titleLabel = new AppLabel
            {
                Text = Details.Title,
                FontSize = 15
            };

            this.Add(titleLabel, 0, 0);
            this.Add(new AppLabel
            {
                Text = Details.Description,
                FontSize = 11
            }, 0, 1);
            this.Add(new AppButton
            {
                Text = "Usuń",
                FontSize = 11,
                OnClick = (sender, args) =>
                {
                    App.db.Delete(Details);
                    RefreshTaskList();
                }
            }, 0, 2);
        }
    }
}
