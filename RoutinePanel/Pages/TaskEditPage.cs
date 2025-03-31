namespace RoutinePanel.Pages;

using System.Diagnostics;
using RoutinePanel.Components;
using RoutinePanel.Lib;
using SQLite;

public class TaskEditPage : ContentPage
{
    private UnorderedList taskList;

    public TaskEditPage()
    {
        taskList = new UnorderedList(new Task[] {});
        RefreshTaskList();
        DisplayAlert("Task count", taskList.Count().ToString(), "OK");

        Title = "Edytuj listê zadañ";

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
                        new AppButton
                        {
                            Text = "+",
                            OnClick = async (sender, args) => {
                                string title = await DisplayPromptAsync("Tytu³", "Podaj tytu³ zadania", "OK", "Anuluj", null, -1, Keyboard.Text, null);
                                if(title == null)
                                {
                                    return;
                                }

                                string description = await DisplayPromptAsync("Opis", "Podaj opis zadania", "OK", "Anuluj", null, -1, Keyboard.Text, null);
                                if(description == null)
                                {
                                    return;
                                }

                                TaskModel taskDetails = new TaskModel
                                {
                                    Title = title,
                                    Description = description
                                };
                                App.db.Insert(taskDetails);

                                RefreshTaskList();
                            }
                        }
                    }
                }
            }
        };
    }
    public void RefreshTaskList()
    {
        Task[] tasksRefreshed = App.db
            .Table<TaskModel>()
            .Select(row => new Task(row, RefreshTaskList))
            .ToArray();
        taskList.RefreshData(tasksRefreshed);
    }
}