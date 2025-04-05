using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoutinePanel.Components.Global;
using RoutinePanel.Lib;
using static System.Net.Mime.MediaTypeNames;

namespace RoutinePanel.Components.TaskEditPage
{
    internal class TaskRepresentationDeletionButton : AppButton
    {
        private new EventHandler OnClick;

        public TaskRepresentationDeletionButton(TaskModel task)
        {
            Text = "Usuń";
            Clicked += async (sender, args) =>
            {
                TaskModel.Delete(task.id);
            };
        }
    }
}
