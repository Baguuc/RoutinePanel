using RoutinePanel.Components.Global;
using RoutinePanel.Lib;

namespace RoutinePanel.Components.TaskCompletionPage
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
