namespace RoutinePanel.Pages;

using RoutinePanel.Components.Global;
using RoutinePanel.Components.TaskCompletionPage;
using RoutinePanel.Lib;
using RoutinePanel.State;

public class TaskCompletionPage : ContentPage
{
    private UnorderedList taskList = new UnorderedList(Array.Empty<TaskRepresentation>());

    public TaskCompletionPage()
    {
        Title = "Zobacz zadania";

        this.Loaded += (_, _) =>
        {
            StateManagers.TaskStateManager.Observe((newData) => RefreshList(newData));

            RefreshList(StateManagers.TaskStateManager.GetValue());
        };

        Content = new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
            Children =
            {
                taskList
            }
        };
    }

    private void RefreshList(List<TaskModel> newData)
    {
        TaskRepresentation[] listItems = newData
            .Select((task => new TaskRepresentation(task)))
            .ToArray();

        taskList.RefreshData(listItems);
    }
}