using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoutinePanel.Components.Global;
using RoutinePanel.Lib;

namespace RoutinePanel.Components.AnalyticsPage
{
    internal class DoneTodayLabel : AppLabel
    {
        public DoneTodayLabel(CompletionRate todaysRate)
        {
            FontSize = 17;
        }

        public void RefreshData(CompletionRate todaysRate)
        {
            Text = $"Dzisiaj zrobiono: {todaysRate.completedCount} / {todaysRate.totalCount}";
        }
    }
}
