using RoutinePanel.Lib;

namespace RoutinePanel.Components;

public class AppButton : Button
{
	public EventHandler OnClick;

	private Color BackroundColor;
	private Color TextColor;
	private Color BorderColor;


    public AppButton()
	{
		BackgroundColor = Constants.ColorScheme.COLOR_2;
		TextColor = Constants.ColorScheme.COLOR_TEXT;
		BorderWidth = 1;
		BorderColor = Constants.ColorScheme.COLOR_4;
		Clicked += (sender, args) =>
		{
            if(OnClick != null) OnClick(sender, args);
		};
		Pressed += (sender, args) =>
		{
			BackgroundColor = Constants.ColorScheme.COLOR_1;
        };
		Released += (sender, args) =>
		{
			BackgroundColor = Constants.ColorScheme.COLOR_2;
        };
	}
}