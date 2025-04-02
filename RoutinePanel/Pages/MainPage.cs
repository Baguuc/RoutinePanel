using RoutinePanel.Lib;
using SQLite;

namespace RoutinePanel.Pages;

public class MainPage : TabbedPage
{
	public MainPage()
	{
		BarBackgroundColor = Constants.ColorScheme.COLOR_4;
		SelectedTabColor = Constants.ColorScheme.COLOR_1;

		this.Children.Add(new TaskCompletionPage());
		this.Children.Add(new TaskEditPage());
    }
}