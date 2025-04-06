namespace RoutinePanel.Pages;

using RoutinePanel.Components.Global;
using RoutinePanel.Components.TaskCompletionPage;
using RoutinePanel.Lib;
using RoutinePanel.State;

public class TaskCompletionPage : ContentPage
{
    private Random random = new Random();
    private VerticalStackLayout rootLayout = new VerticalStackLayout
    {
        VerticalOptions = LayoutOptions.Fill,
        HorizontalOptions = LayoutOptions.Fill
    };
    private AbsoluteLayout animationBox = new AbsoluteLayout
    {
        VerticalOptions = LayoutOptions.Fill,
        HorizontalOptions = LayoutOptions.Fill,
    };
    private VerticalStackLayout mainLayout = new VerticalStackLayout
    {
        VerticalOptions = LayoutOptions.Fill,
        HorizontalOptions = LayoutOptions.Fill,
    };

    public TaskCompletionPage()
    {
        Title = "Zobacz zadania";
        UnorderedList taskList = new UnorderedList(Array.Empty<TaskRepresentation>());

        this.Loaded += (_, _) =>
            StateManagers.TaskStateManager.RunAndObserve((newData) =>
            {
                TaskRepresentation[] listItems = newData
                    .Select((task => new TaskRepresentation(task, DisplayCompletionAnimation)))
                    .ToArray();

                taskList.RefreshItems(listItems);
            });

        mainLayout.Children.Add(taskList);

        rootLayout.Children.Add(animationBox);
        rootLayout.Children.Add(mainLayout);

        rootLayout.Loaded += (_, _) =>
        {
            animationBox.WidthRequest = Window.Width;
            animationBox.HeightRequest = Window.Height / 4;
            mainLayout.WidthRequest = Window.Width;
            mainLayout.HeightRequest = (Window.Height / 4) * 3;
        };

        Content = rootLayout;
    }

    private void DisplayCompletionAnimation()
    {
        Action[] animations =
        {
            () => DisplayCompletionAnimation("👍", 1.1, 0.9, 0.2),
            () => DisplayCompletionAnimation("😎", 1.1, 0.9, 0.2),
            () => DisplayCompletionAnimation("Super!", 1.01, 0.95, 0.2),
            () => DisplayCompletionAnimation("Tak trzymaj!", 1.01, 0.95, 0.2)
        };
        
        int choice = random.Next(0, animations.Length);
        animations[choice]();
    }

    private void DisplayCompletionAnimation(string text, double scaleFirstPart, double scaleSecondPart, double opacityPerTick)
    {
        Label animationLabel = new Label
        {
            HorizontalTextAlignment = TextAlignment.Center,
            Text = text,
            FontSize = 41,
            ZIndex = 1000,
            TranslationX = animationBox.Width / 2,
            TranslationY = animationBox.Height / 2
        };
        animationLabel.Loaded += (_, _) =>
        {
            int tickCount = 0;
            var timer = Application.Current.Dispatcher.CreateTimer();
            timer.Interval = TimeSpan.FromMilliseconds(25);
            timer.Tick += (s, e) =>
            {
                if (tickCount > 15)
                {
                    timer.Stop();
                    animationBox.Children.Clear();
                    return;
                }

                if (tickCount <= 10)
                {
                    animationLabel.Scale *= scaleFirstPart;
                }
                else
                {
                    animationLabel.Scale *= scaleSecondPart;
                    animationLabel.Opacity -= opacityPerTick;
                }
                tickCount++;
            };
            timer.Start();
        };
        animationBox.Add(animationLabel);
    }
}