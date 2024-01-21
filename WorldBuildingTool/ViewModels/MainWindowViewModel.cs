using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuildingTool.Models;

namespace WorldBuildingTool.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public TimelineViewModel TimelineViewModel { get; }
        public MainWindowModel MainWindowModel { get; }
        public MainWindowViewModel()
        {
            this.TimelineViewModel = new TimelineViewModel();
            this.MainWindowModel = new MainWindowModel();
        }
    }
}
