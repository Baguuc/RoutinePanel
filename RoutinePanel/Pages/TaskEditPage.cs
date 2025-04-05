namespace RoutinePanel.Pages;

using RoutinePanel.Components.TaskEditPage;
using RoutinePanel.Components.Global;
using RoutinePanel.Lib;
using RoutinePanel.State;

public class TaskEditPage : ContentPage
{
    public TaskEditPage()
    {
        Title = "Edytuj listê zadañ";
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
                new VerticalStackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    BackgroundColor = Constants.ColorScheme.COLOR_1,
                    Children = {
                        taskList,
                        new TaskAdditionButton()
                    }
                }
            }
        };
    }
}