using RoutinePanel.Components.AnalyticsPage;
using RoutinePanel.Components.Global;
using RoutinePanel.Lib;
using RoutinePanel.State;

namespace RoutinePanel.Pages
{
    internal class AnalyticsPage : ContentPage
    {
        public AnalyticsPage()
        {
            Title = "Statystyki";
            List<CompletionRate> completionRates = new List<CompletionRate>();
            CompletionRate todaysRate = new CompletionRate(DateTime.Now, 0, 0, 0);

            var progressLabel = new LastWeekProgresLabel(completionRates);
            var doneLabel = new DoneTodayLabel(todaysRate);
            var doneProgressBar = new DoneTodayProgressBar(todaysRate);

            this.Loaded += (_, _) =>
                StateManagers.TaskStateManager.RunAndObserve((newData) =>
                {
                    List<CompletionRate> newCompletionRates = TaskCompletionModel.GetCompletionRatesForLast7Days();
                    CompletionRate newTodaysRate = TaskCompletionModel.GetTodaysCompletionRate();

                    progressLabel.RefreshData(newCompletionRates);
                    doneLabel.RefreshData(newTodaysRate);
                    doneProgressBar.RefreshData(newTodaysRate);
                });

            Content = new VerticalStackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 8,
                Children =
                {
                    progressLabel,
                    doneLabel,
                    doneProgressBar
                }
            };
        }
    }
}
