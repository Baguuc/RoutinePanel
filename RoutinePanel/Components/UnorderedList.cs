namespace RoutinePanel.Components.Global
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
