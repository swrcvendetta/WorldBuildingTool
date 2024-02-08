using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldBuildingTool.ViewModels;

namespace WorldBuildingTool.Views.Controls
{
    /// <summary>
    /// Interaktionslogik für TimelineControl.xaml
    /// </summary>
    public partial class TimelineControl : UserControl
    {
        private int _scale;
        private int _scaleFactor;
        private int _minZoom;
        private int _maxZoom;
        private ScaleTransform _scaleTransform;
        private TranslateTransform _translateTransform;
        private TransformGroup _transformGroup;
        private Point _prevMousePos;

        public TimelineControl()
        {
            InitializeComponent();

            // Inits

            _scale = 10;        // Using int we can avoid double precision error
            _scaleFactor = 1;
            _minZoom = 2;
            _maxZoom = 50;
            _translateTransform = new TranslateTransform();
            _scaleTransform = new ScaleTransform();
            _transformGroup = new TransformGroup();
            _transformGroup.Children.Add(_scaleTransform);
            _transformGroup.Children.Add(_translateTransform);
            this.canvas_timeline.RenderTransform = _transformGroup;
            _prevMousePos = new Point();

            // Add Events

            this.border.MouseMove += new MouseEventHandler(Event_border_MouseMove);
            this.border.MouseWheel += new MouseWheelEventHandler(Event_border_MouseWheel);
            this.btn_CurrentTick.Click += new RoutedEventHandler(Event_btn_CurrentTick_Click);
            this.btn_jumpToVeryFirstTick.Click += new RoutedEventHandler(Event_btn_jumpToVeryFirstTick_Click);
            this.btn_jumpToVeryLastTick.Click += new RoutedEventHandler(Event_btn_jumpToVeryLastTick_Click);
            this.btn_nextSubTick.Click += new RoutedEventHandler(Event_btn_nextSubTick_Click);
            this.btn_nextTick.Click += new RoutedEventHandler(Event_btn_nextTick_Click);
            this.btn_prevSubTick.Click += new RoutedEventHandler(Event_btn_prevSubTick_Click);
            this.btn_prevTick.Click += new RoutedEventHandler(Event_btn_prevTick_Click);
            this.btn_TogglePlay.Click += new RoutedEventHandler(Event_btn_TogglePlay_Click);
            this.canvas_indicator.Loaded += new RoutedEventHandler(Event_canvas_indicator_Loaded);
            this.SizeChanged += new SizeChangedEventHandler(Event_SizeChanged);
            this.Loaded += new RoutedEventHandler(Event_Loaded);

            // Debug
            
            Rectangle rect = new Rectangle()
            {
                Width = 20,
                Height = 20,
                Fill = new SolidColorBrush(Colors.Red),
            };
            Ellipse ellipse = new Ellipse()
            {
                Width = 20,
                Height = 20,
                Fill = new SolidColorBrush(Colors.Blue),
            };
            this.canvas_timeline.Children.Add(rect);
            this.canvas_timeline.Children.Add(ellipse);
            Canvas.SetLeft(rect, 50);
            Canvas.SetLeft(ellipse, 250);
           
        }

        private void Event_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
                ((ViewModelBase)this.DataContext).PropertyChanged += TimelineControl_PropertyChanged;
        }
        
        private void TimelineControl_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "CurrentTick" && DataContext != null)
            {
                CursorJumpToTick(((TimelineViewModel)this.DataContext).CurrentTick * 10.0);
            }
        }

        private void CursorJumpToTick(double offset)
        {
            _translateTransform.X = -offset;
            _translateTransform.Y = 0.0;
            // Update Canvas
            this.img_timeline_indicator.Source = CalculateTimelineIndicator();
        }

        private void Event_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.img_timeline_indicator.Source = CalculateTimelineIndicator();
        }

        private void Event_canvas_indicator_Loaded(object sender, RoutedEventArgs e)
        {
            this.img_timeline_indicator.Source = CalculateTimelineIndicator();
        }

        private void Event_border_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0 && _scale < _maxZoom)
                _scale += _scaleFactor;
            else if (e.Delta < 0 && _scale > _minZoom)
                _scale -= _scaleFactor;
            this.lbl_canvas_scale.Content = $"{_scale / 10.0}x";
            Zoom(e.GetPosition(this));
        }

        private void Zoom(Point point)
        {
            double centerX = (point.X - _translateTransform.X) / _scaleTransform.ScaleX;
            double centerY = (0.0 - _translateTransform.Y) / _scaleTransform.ScaleY;
            _scaleTransform.ScaleX = _scale / 10.0;
            _scaleTransform.ScaleY = _scale / 10.0;
            _translateTransform.X = point.X - centerX * _scaleTransform.ScaleX;
            _translateTransform.Y = 0.0 - centerY * _scaleTransform.ScaleY;
            // Update Canvas
            this.img_timeline_indicator.Source = CalculateTimelineIndicator();
        }

        private void Event_border_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.RightButton == MouseButtonState.Pressed)
            {
                _translateTransform.X = this.canvas_timeline.RenderTransform.Value.OffsetX - (_prevMousePos.X - e.GetPosition(this).X);
                _translateTransform.Y = 0.0;
                // Update Canvas
                this.img_timeline_indicator.Source = CalculateTimelineIndicator();
            }
            _prevMousePos = e.GetPosition(this);
        }

        private BitmapSource CalculateTimelineIndicator()
        {
            int width = (int)this.canvas_indicator.ActualWidth;
            int height = (int)this.canvas_indicator.ActualHeight;
            var pixels = new byte[4 * width * height];
            for (int x = 0; x < width; x++) 
            {
                double value = Math.Truncate(
                    (Math.Truncate(_translateTransform.X) - x) / (_scale / 10.0));
                if (value % 10.0 == 0.0)
                {
                    for (int y = height / 2; y < height; y++)
                    {
                        int index = y * width + x;
                        pixels[index * 4] = 63;
                        pixels[index * 4 + 1] = 63;
                        pixels[index * 4 + 2] = 63;
                        pixels[index * 4 + 3] = 255;
                    }
                }
                if(value % 100.0 == 0.0)
                {
                    for (int y = 0; y < height; y++)
                    {
                        int index = y * width + x;
                        pixels[index * 4] = 127;
                        pixels[index * 4 + 1] = 127;
                        pixels[index * 4 + 2] = 127;
                        pixels[index * 4 + 3] = 255;
                    }
                }
                // pixels[((height - 1) * width + x) * 4 + 3] = 255; // black line at bottom
            }
            return BitmapSource.Create(
                width, height, 96d, 96d, PixelFormats.Bgra32, null, pixels, width * 4);
        }

        private void Event_btn_TogglePlay_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void Event_btn_prevTick_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void Event_btn_prevSubTick_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void Event_btn_nextTick_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void Event_btn_nextSubTick_Click(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void Event_btn_jumpToVeryLastTick_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Event_btn_jumpToVeryFirstTick_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Event_btn_CurrentTick_Click(object sender, RoutedEventArgs e)
        {
            if(DataContext != null)
                CursorJumpToTick(((TimelineViewModel)this.DataContext).CurrentTick * 10.0);
        }
    }
}
