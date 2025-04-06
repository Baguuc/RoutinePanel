using RoutinePanel.Components.Global;
using RoutinePanel.Lib;

namespace RoutinePanel.Components.TaskCompletionPage
{
    internal class TaskRepresentation : Grid
    {
        public TaskRepresentation(TaskModel task, Action DisplayCompletionAnimation)
        {
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
            Padding = 8;

            this.Add(new TaskRepresentationTitle(task), 0, 0);
            this.Add(new TaskRepresentationDescription(task), 0, 1);
            this.Add(new TaskCompletionButton(task, DisplayCompletionAnimation), 0, 2);
        }
    }
}