using RoutinePanel.Components.Global;
using RoutinePanel.Lib;

namespace RoutinePanel.Components.TaskEditPage
{
    internal class TaskAdditionButton : AppButton
    {
        private new EventHandler OnClick;

        public TaskAdditionButton()
        {
            Text = "+";
            Clicked += async (sender, args) =>
            {
                string title = await Window.Page.DisplayPromptAsync("Tytuł", "Podaj tytuł zadania", "OK", "Anuluj", null, -1, Keyboard.Text, null);
                if (title == null)
                {
                    return;
                }

                string description = await Window.Page.DisplayPromptAsync("Opis", "Podaj opis zadania", "OK", "Anuluj", null, -1, Keyboard.Text, null);
                if (description == null)
                {
                    return;
                }

                TaskModel taskDetails = new TaskModel(title, description);
                TaskModel.Insert(taskDetails);
            };
        }
    }
}
