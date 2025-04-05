using RoutinePanel.Components.Global;
using RoutinePanel.Lib;

namespace RoutinePanel.Components.TaskEditPage
{
    internal class TaskRepresentationDescription : AppLabel
    {
        public TaskRepresentationDescription(TaskModel task)
        {
            Text = task.description;
            FontSize = 11;
        }
    }
}
