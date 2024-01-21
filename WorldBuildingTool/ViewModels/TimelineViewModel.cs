using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorldBuildingTool.Commands;
using WorldBuildingTool.Models;

namespace WorldBuildingTool.ViewModels
{
    public class TimelineViewModel : ViewModelBase
    {
        private TimelineModel _timeline;

        public ICommand TogglePlayCommand { get; }
        public ICommand NextSubTickCommand { get; }
        public ICommand NextTickCommand { get; }
        public ICommand PreviousSubTickCommand { get; }
        public ICommand PreviousTickCommand { get; }

        public TimelineViewModel()
        {
            this._timeline = new TimelineModel();
            this._timeline.PropertyChanged += _timeline_PropertyChanged;
            TogglePlayCommand = new TimelineTogglePlayCommand(this);
            NextTickCommand = new TimelineNextTickCommand(this);
            NextSubTickCommand = new TimelineNextSubTickCommand(this);
            PreviousTickCommand = new TimelinePreviousTickCommand(this);
            PreviousSubTickCommand = new TimelinePreviousSubTickCommand(this);

        }

        private void _timeline_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            CurrentTick = _timeline.currentTick;
        }

        public bool IsPlaying
        {
            get => _timeline.bIsPlaying;
            set
            {
                _timeline.bIsPlaying = value;
                _timeline.ToggleTimer();
                OnPropertyChanged(nameof(IsPlaying));
            }
        }

        public double FirstTick
        {
            get => _timeline.firstTick;
            set
            {
                _timeline.firstTick = value;
                OnPropertyChanged(nameof(FirstTick));
            }
        }

        public double CurrentTick
        {
            get => _timeline.currentTick;
            set
            {
                _timeline.currentTick = value;
                OnPropertyChanged(nameof(CurrentTick));
            }
        }

        public double LastTick
        {
            get => _timeline.lastTick;
            set
            {
                _timeline.lastTick = value;
                OnPropertyChanged(nameof(LastTick));
            }
        }

    }
}
