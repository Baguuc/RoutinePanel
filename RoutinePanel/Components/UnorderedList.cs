using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace RoutinePanel.Components
{
    class UnorderedList : Grid
    {
        public UnorderedList(IView[] _children)
        {
            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition()
            };
            RowDefinitionCollection rows = new RowDefinitionCollection();

            RowSpacing = 6;

            foreach (IView child in _children)
            {
                rows.Add(new RowDefinition());
                Children.Add(child);
            }
        }
    }
}
