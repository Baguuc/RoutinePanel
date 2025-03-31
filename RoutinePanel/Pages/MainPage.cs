using RoutinePanel.Lib;

namespace RoutinePanel.Pages;

public class MainPage : TabbedPage
{
	public MainPage()
	{
		BarBackgroundColor = Constants.ColorScheme.COLOR_4;
		SelectedTabColor = Constants.ColorScheme.COLOR_1;

		this.Children.Add(new TaskEditPage());
    }
}