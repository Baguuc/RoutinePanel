using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoutinePanel.Components.Global;
using RoutinePanel.Lib;

namespace RoutinePanel.Components.AnalyticsPage
{
    internal class DoneTodayProgressBar : ProgressBar
    {
        public DoneTodayProgressBar(CompletionRate todaysRate)
        {
            WidthRequest = 200;   
            BackgroundColor = Constants.ColorScheme.COLOR_1;
            ProgressColor = Constants.ColorScheme.COLOR_4;
            Margin = 8;
            ScaleY = 2;
        }

        public void RefreshData(CompletionRate todaysRate)
        {
            Progress = (float)((float)todaysRate.completionPercentage / 100f);
        }
    }
}
