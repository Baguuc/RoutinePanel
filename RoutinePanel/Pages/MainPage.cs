using RoutinePanel.Lib;
using RoutinePanel.State;

namespace RoutinePanel.Pages;

public class MainPage : TabbedPage
{
	public MainPage()
	{
		BarBackgroundColor = Constants.ColorScheme.COLOR_4;
		SelectedTabColor = Constants.ColorScheme.COLOR_1;

		this.Children.Add(new TaskCompletionPage());
		this.Children.Add(new TaskEditPage());
		this.Children.Add(new AnalyticsPage());

        StateManagers.TaskStateManager.Update(TaskModel.SelectAll());
    }
}