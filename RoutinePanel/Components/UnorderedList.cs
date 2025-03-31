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
            RefreshData(_children);
        }

        public void RefreshData(IView[] _children)
        {
            this.Clear();
            RowDefinitions.Clear();
            RowSpacing = 6;

            int row = 0;
            foreach (IView child in _children)
            {
                RowDefinitions.Add(new RowDefinition());
                this.Add(child, 0, row);
                row++;
            }
        }
    }
}
