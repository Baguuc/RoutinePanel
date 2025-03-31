namespace RoutinePanel.Pages;

using RoutinePanel.Components;
using RoutinePanel.Lib;

public class TaskEditPage : ContentPage
{
	public TaskEditPage()
	{
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
                        new UnorderedList(new Task[]
                        {
                            new Task(new DbTask 
                            { 
                                Title = "Zrób prace domow¹",
                                Description = "Zadania matematyka 1,2,3/206, 1,6,8/209, 20,31,36/230"
                            })
                        }),
                        new UnorderedList(new Task[]
                        {
                            new Task(new DbTask
                            {
                                Title = "Zrób prace domow¹ 2",
                                Description = "Zadania polski 1,2,3/119"
                            })
                        }),
                        new AppButton
                        {
                            Text = "+",
                            OnClick = (sender, args) => {
                                DisplayAlert("Hello", "", "OK");
                            }
                        }
                    }
                }
            }
        };
	}
}