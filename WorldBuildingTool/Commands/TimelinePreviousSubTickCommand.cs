using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuildingTool.ViewModels;

namespace WorldBuildingTool.Commands
{
    public class TimelinePreviousSubTickCommand : CommandBase
    {
        private TimelineViewModel _viewModel;
        public TimelinePreviousSubTickCommand(TimelineViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _viewModel.CurrentTick = Math.Round(_viewModel.CurrentTick - 0.2, 1);
        }
    }
}
