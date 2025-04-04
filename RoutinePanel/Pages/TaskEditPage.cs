namespace RoutinePanel.Pages;

using RoutinePanel.Components.TaskEditPage;
using RoutinePanel.Components.Global;
using RoutinePanel.Lib;
using RoutinePanel.State;

public class TaskEditPage : ContentPage
{
    private UnorderedList taskList = new UnorderedList(Array.Empty<TaskRepresentation>());

    public TaskEditPage()
    {
        Title = "Edytuj listê zadañ";

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
    public void RefreshList(List<TaskModel> newData)
    {
        TaskRepresentation[] listItems = newData
            .Select((task => new TaskRepresentation(task)))
            .ToArray();

        taskList.RefreshData(listItems);
    }
}