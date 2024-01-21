using WorldBuildingTool.ViewModels;

namespace WorldBuildingTool.Commands
{
    public class TimelineNextSubTickCommand : CommandBase
    {
        private TimelineViewModel _timelinevm;
        public TimelineNextSubTickCommand(TimelineViewModel timelineVM)
        {
            this._timelinevm = timelineVM;
        }

        public override void Execute(object? parameter)
        {
            _timelinevm.CurrentTick = Math.Round(_timelinevm.CurrentTick + 0.2, 1);
        }
    }
}
