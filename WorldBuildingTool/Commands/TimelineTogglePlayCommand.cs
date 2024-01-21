using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuildingTool.ViewModels;

namespace WorldBuildingTool.Commands
{
    public class TimelineTogglePlayCommand : CommandBase
    {
        private TimelineViewModel _timelinevm;
        public TimelineTogglePlayCommand(TimelineViewModel timelinevm)
        { 
            this._timelinevm = timelinevm;
        }

        public override void Execute(object? parameter)
        {
            _timelinevm.IsPlaying = !_timelinevm.IsPlaying;
        }
    }
}
