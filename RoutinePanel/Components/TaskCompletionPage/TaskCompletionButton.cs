using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoutinePanel.Components.Global;
using RoutinePanel.Lib;

namespace RoutinePanel.Components.TaskCompletionPage
{
    internal class TaskCompletionButton : AppButton
    {
        private new EventHandler OnClick;

        public TaskCompletionButton(TaskModel task)
        {
            if (task.completed)
            {
                Text = "Oznacz jako nieukończone";
                Clicked += (_, _) =>
                {
                    int? completionId = TaskModel.GetCompletionId(task, DateTime.Now);

                    if (completionId == null)
                    {
                        return;
                    }

                    TaskCompletionModel.Delete((int)completionId);
                };
            }
            else
            {
                Text = "Oznacz jako ukończone";
                Clicked += (_, _) =>
                {
                    TaskCompletionModel.Insert(task.id);
                };
            }
        }
    }
}
