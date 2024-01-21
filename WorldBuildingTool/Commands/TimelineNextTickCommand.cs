using WorldBuildingTool.ViewModels;

namespace WorldBuildingTool.Commands
{
    public class TimelineNextTickCommand : CommandBase
    {
        private TimelineViewModel _timelinevm;
        public TimelineNextTickCommand(TimelineViewModel timelinevm)
        {
            _timelinevm = timelinevm;
        }
        public override void Execute(object? parameter)
        {
            _timelinevm.CurrentTick = Math.Round(_timelinevm.CurrentTick + 1.0, 1);
        }
    }
}
