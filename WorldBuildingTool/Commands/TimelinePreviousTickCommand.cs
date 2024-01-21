using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuildingTool.ViewModels;

namespace WorldBuildingTool.Commands
{
    public class TimelinePreviousTickCommand : CommandBase
    {
        private TimelineViewModel _viewModel;
        public TimelinePreviousTickCommand(TimelineViewModel timelinevm)
        {
            _viewModel = timelinevm;
        }
        public override void Execute(object? parameter)
        {
            _viewModel.CurrentTick = Math.Round(_viewModel.CurrentTick - 1.0, 1);
        }
    }
}
