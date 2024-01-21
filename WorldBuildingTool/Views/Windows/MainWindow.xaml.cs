using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WorldBuildingTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double windowHeightOffset = 40.0;
        private bool bSelectedBorder_Timeline;
        public MainWindow()
        {
            InitializeComponent();

            bSelectedBorder_Timeline = false;

            this.MouseMove += new MouseEventHandler(Event_MouseMove);
            this.MouseUp += new MouseButtonEventHandler(Event_MouseUp);
            this.timeline_border.MouseDown += new MouseButtonEventHandler(Event_timeline_border_MouseDown);
            this.timeline_border.Cursor = Cursors.SizeNS;
        }

        private void Event_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (bSelectedBorder_Timeline)
                bSelectedBorder_Timeline = false;
        }

        private void Event_timeline_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bSelectedBorder_Timeline = true;
        }

        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            if (bSelectedBorder_Timeline)
            {
                this.timeline.Height = this.ActualHeight - e.GetPosition(this).Y - windowHeightOffset;
            }
        }
    }
}