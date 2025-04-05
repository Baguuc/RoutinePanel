namespace RoutinePanel.Pages;

using RoutinePanel.Components.Global;
using RoutinePanel.Components.TaskCompletionPage;
using RoutinePanel.Lib;
using RoutinePanel.State;

public class TaskCompletionPage : ContentPage
{
    public TaskCompletionPage()
    {
        Title = "Zobacz zadania";
        UnorderedList taskList = new UnorderedList(Array.Empty<TaskRepresentation>());

        this.Loaded += (_, _) =>
            StateManagers.TaskStateManager.RunAndObserve((newData) =>
            {
                TaskRepresentation[] listItems = newData
                    .Select((task => new TaskRepresentation(task)))
                    .ToArray();

                taskList.RefreshItems(listItems);
            });

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
}