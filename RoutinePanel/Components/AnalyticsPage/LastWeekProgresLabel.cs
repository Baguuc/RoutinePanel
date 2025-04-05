using RoutinePanel.Components.Global;
using RoutinePanel.Lib;

namespace RoutinePanel.Components.AnalyticsPage
{
    internal class LastWeekProgresLabel : AppLabel
    {
        public LastWeekProgresLabel(List<CompletionRate> completionRates)
        {
            FontSize = 17;
            RefreshData(completionRates);
        }

        public void RefreshData(List<CompletionRate> completionRates)
        {
            if(completionRates.Count < 2)
            {
                return;
            }

            int[] lastCompletionPercentages =
            {
                completionRates[completionRates.Count - 1].completionPercentage,
                completionRates[0].completionPercentage
            };
            int lastWeekChange = lastCompletionPercentages[0] - lastCompletionPercentages[1];

            string changeString = "";

            if(lastWeekChange == 0 && lastCompletionPercentages[0] == 100)
            {
                changeString = "niezmienne 100% 👌";
            }

            if(lastWeekChange == 0 && lastCompletionPercentages[0] != 100)
            {
                changeString = "0 zmian 😒";
            }

            if(lastWeekChange != 0 && lastWeekChange > 0)
            {
                changeString = $"{lastWeekChange}% 👍";
            }

            if (lastWeekChange != 0 && lastWeekChange < 0)
            {
                changeString = $"{lastWeekChange}% 👎";
            }

            Text = $"Postęp przez ostatni tydzień: {changeString}";
        }
    }
}
