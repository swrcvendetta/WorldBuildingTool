namespace WorldBuildingTool.Models
{
    public class TimelineModel : ModelBase
    {
        public bool bIsPlaying;
        public double firstTick;
        public double lastTick;
        private double _currentTick;


        CancellationTokenSource CTS;

        public TimelineModel()
        {
            this.bIsPlaying = false;
            this.firstTick = 0.0;
            this.lastTick = 0.0;
            this._currentTick = Timeline.Tick;

            CTS = new CancellationTokenSource();
        }

        public TimelineModel(double firstTick, double lastTick, double currentTick)
        {
            this.bIsPlaying = false;
            this.firstTick = firstTick;
            this.lastTick = lastTick;
            Timeline.Tick = currentTick;
            this._currentTick = Timeline.Tick;
            CTS = new CancellationTokenSource();
        }

        public double CurrentTick
        {
            get => this._currentTick;
            set
            {
                if(this._currentTick != value)
                {
                    Timeline.Tick = value;
                    _currentTick = value;

                    OnPropertyChanged(nameof(CurrentTick));
                }
            }
        }

        public void ToggleTimer()
        {
            if ( bIsPlaying )
            {
                CTS = new CancellationTokenSource();
                Task t = PeriodicTask.Run(IncreaseTick, new TimeSpan(0, 0, 0, 0, 50), CTS.Token);
            }
            else
            {
                CTS.CancelAsync();
                CTS.Dispose();
            }
        }

        void IncreaseTick()
        {
            Timeline.Tick = Timeline.Tick + 0.2;
            this._currentTick = Timeline.Tick;
            
            OnPropertyChanged(nameof(CurrentTick));
        }

        public class PeriodicTask
        {
            public static async Task Run(Action action, TimeSpan period, CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(period, cancellationToken).ContinueWith(tsk => { });

                    if (!cancellationToken.IsCancellationRequested)
                        action();
                }
            }

            public static Task Run(Action action, TimeSpan period)
            {
                return Run(action, period, CancellationToken.None);
            }
        }
    }
}
