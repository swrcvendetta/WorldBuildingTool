namespace WorldBuildingTool.Models
{
    public class TimelineModel : ModelBase
    {
        public bool bIsPlaying;
        public double firstTick;
        public double lastTick;
        public double currentTick;


        CancellationTokenSource CTS;

        public TimelineModel()
        {
            this.bIsPlaying = false;
            this.firstTick = 0.0;
            this.lastTick = 0.0;
            this.currentTick = 0.0;

            CTS = new CancellationTokenSource();
        }

        public TimelineModel(double firstTick, double lastTick, double currentTick)
        {
            this.bIsPlaying = false;
            this.firstTick = firstTick;
            this.lastTick = lastTick;
            this.currentTick = currentTick;
            CTS = new CancellationTokenSource();
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
            this.currentTick = Math.Round(currentTick + 0.2, 1);
            
            OnPropertyChanged(nameof(currentTick));
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
