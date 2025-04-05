using RoutinePanel.Components.Global;
using RoutinePanel.Lib;

namespace RoutinePanel.Components.TaskEditPage
{
    internal class TaskRepresentationTitle : AppLabel
    {
        public TaskRepresentationTitle(TaskModel task)
        {
            Text = task.title;
            FontSize = 15;
        }
    }
}
