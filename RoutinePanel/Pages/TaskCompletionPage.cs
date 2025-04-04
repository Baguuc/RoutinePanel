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
        TaskModel[] tasks = TaskModel.SelectAll()
            .ToArray();

        TaskCompletion[] labels = tasks.Select(task =>
        {
            return new TaskCompletion(task, RefreshTaskList);
        })
        .ToArray();

        taskList.RefreshData(labels);
    }
}