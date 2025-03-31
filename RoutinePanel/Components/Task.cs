using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoutinePanel.Lib;

namespace RoutinePanel.Components
{
    internal class Task : Grid
    {
        public DbTask Details { get; set; }

        public Task(DbTask details)
        {
            Padding = 8;
            Details = details;

            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition()
            };
            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition(),
                new RowDefinition()
            };
            RowSpacing = 4;

            WidthRequest = 200;
            Label titleLabel = new AppLabel
            {
                Text = Details.Title,
                FontSize = 15
            };

            this.Add(titleLabel, 0, 0);
            this.Add(new AppLabel
            {
                Text = Details.Description,
                FontSize = 11
            }, 0, 1);
        }
    }
}
