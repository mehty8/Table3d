using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Table3d
{
    public partial class MainWindow : Window
    {
        private Table _table;
        private List<IEngine> _engines;
        private List<Slider> _sliders;
        
        public MainWindow()
        {
            InitializeComponent();
            _table = new Table();
            _engines = new() { new EngineX(), new EngineY(), new EngineZ() };
            _sliders = new() { XSlider, YSlider, ZSlider };
            TableCanvas.MouseLeftButtonDown += CanvasMouseLeftButtonDown;
        }
        
        private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(TableCanvas);
            
            DoubleAnimation animationX = new DoubleAnimation
            {
                To = mousePosition.X,  
                Duration = TimeSpan.FromSeconds(1), 
                EasingFunction = new QuadraticEase() 
            };
            
            DoubleAnimation animationY= new DoubleAnimation
            {
                To = mousePosition.Y,  
                Duration = TimeSpan.FromSeconds(1), 
                EasingFunction = new QuadraticEase() 
            };
            
            TableRectangle.BeginAnimation(Canvas.LeftProperty, animationX);
            TableRectangle.BeginAnimation(Canvas.TopProperty, animationY);
            
            UpdateUI();
        }
        
        
        private async void MoveAxisClick(object sender, RoutedEventArgs e)
        {
            string axis = Regex.Replace($"{sender}", "[^XYZ]", "");
            foreach (var engine in _engines)
            {
                if (engine.MoveAxis(axis, _table, _sliders, 10, TableRectangle))
                {
                    break;
                };
            }
            UpdateUI();
            await Task.Delay(1000);
        }
        private void UpdateUI()
        {
            LabelXPosition.Content = $"X: {_table.PositionX}";
            LabelYPosition.Content = $"Y: {_table.PositionY}";
            LabelZPosition.Content = $"Z: {_table.PositionZ}";
            
            LabelXRange.Content = "X Range: 0-100";
            LabelYRange.Content = "Y Range: 0-100";
            LabelZRange.Content = "Z Range: 0-100";
        }

    }
}