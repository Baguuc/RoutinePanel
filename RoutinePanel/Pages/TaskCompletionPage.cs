namespace RoutinePanel.Pages;

using System.Diagnostics;
using RoutinePanel.Components;
using RoutinePanel.Lib;
using SQLite;

public class TaskCompletionPage : ContentPage
{
    private UnorderedList taskList;

    public TaskCompletionPage()
    {
        taskList = new UnorderedList(new Task[] { });
        Title = "Zobacz zadania";

        this.Loaded += (_, _) => RefreshTaskList();

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

    public void RefreshTaskList()
    {
        int[] completionIds = App.db
            .Table<TaskCompletionModel>()
            .Select(completion => completion.TaskId)
            .ToArray();

        TaskModel[] tasks = App.db.Table<TaskModel>()
            .ToArray();

        HashSet<int> taskIds = tasks.Select(task => task.Id)
            .ToHashSet();
        HashSet<int> completedTasksIds = taskIds.Where(id => completionIds.Contains(id))
            .ToHashSet();

        TaskCompletion[] labels = tasks.Select(task =>
        {
            return new TaskCompletion(task, completedTasksIds.Contains(task.Id), RefreshTaskList);
        })
        .ToArray();

        taskList.RefreshData(labels);
    }
}