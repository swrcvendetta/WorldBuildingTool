using System.Windows.Controls;

namespace WorldBuildingTool.Views.Controls
{
    /// <summary>
    /// Interaktionslogik für MapControl.xaml
    /// </summary>
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();
            ComboBoxItem comboBoxItem = new ComboBoxItem()
            {
                Content = "All",
            };
            this.cmbox_filter.Items.Add(comboBoxItem);
            this.cmbox_filter.SelectedIndex = 0;
        }
    }
}
