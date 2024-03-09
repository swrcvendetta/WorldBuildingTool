using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorldBuildingTool.Models;

namespace WorldBuildingTool.Views.Controls
{
    /// <summary>
    /// Interaktionslogik für ActorControl.xaml
    /// </summary>
    public partial class ActorControl : UserControl
    {
        private bool bSelectedBorder_actors;
        private bool bSelectedBorder_actorRefs;

        public ActorControl()
        {
            InitializeComponent();
            this.cmbox_filter_actors.Items.Add("All");
            this.cmbox_filter_actors.SelectedIndex = 0;
            this.cmbox_filter_actor_refs.Items.Add("All");
            this.cmbox_filter_actor_refs.SelectedIndex = 0;

            bSelectedBorder_actors = false;
            bSelectedBorder_actorRefs = false;

            this.MouseMove += new MouseEventHandler(Event_MouseMove);
            this.MouseUp += new MouseButtonEventHandler(Event_MouseUp);
            this.MouseLeave += new MouseEventHandler(Event_MouseLeave);
            this.border_actors.MouseDown += new MouseButtonEventHandler(Event_border_actors_MouseDown);
            this.border_actor_refs.MouseDown += new MouseButtonEventHandler(Event_border_actors_refs_MouseDown);
            this.border_actors.Cursor = Cursors.SizeWE;
            this.border_actor_refs.Cursor = Cursors.SizeWE;
        }

        private void Event_MouseLeave(object sender, MouseEventArgs e)
        {
            bSelectedBorder_actors = false;
            bSelectedBorder_actorRefs = false;
        }

        private void Event_border_actors_refs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bSelectedBorder_actorRefs = true;
        }

        private void Event_MouseUp(object sender, MouseButtonEventArgs e)
        {
                bSelectedBorder_actors = false;
                bSelectedBorder_actorRefs = false;
        }

        private void Event_border_actors_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bSelectedBorder_actors = true;
        }

        private void Event_MouseMove(object sender, MouseEventArgs e)
        {
            if (bSelectedBorder_actors)
            {
                double newWidth = e.GetPosition(this).X;
                double maxWidth = this.ActualWidth - this.border_actors.ActualWidth - this.pnl_actor_refs.ActualWidth - this.border_actor_refs.ActualWidth - this.border_properties.ActualWidth;
                if (newWidth >= this.pnl_actors.MinWidth && newWidth <= maxWidth)
                {
                    this.pnl_actors.Width = newWidth;
                }
            }

            if (bSelectedBorder_actorRefs)
            {
                double newWidth = e.GetPosition(this).X - this.pnl_actors.ActualWidth - this.border_actors.ActualWidth;
                double maxWidth = this.ActualWidth - this.pnl_actors.ActualWidth - this.border_actors.ActualWidth - this.border_actor_refs.ActualWidth - this.border_properties.ActualWidth;
                if (newWidth >= this.pnl_actor_refs.MinWidth && newWidth <= maxWidth)
                {
                    this.pnl_actor_refs.Width = newWidth;
                }
            }
        }
    }
}
