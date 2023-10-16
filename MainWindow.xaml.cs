using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Table3d
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            _sliders = new() { XSpeedSlider, YSpeedSlider, ZSpeedSlider };
            TableCanvas.MouseLeftButtonDown += CanvasMouseLeftButtonDown;
        }
        private void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(TableCanvas);

            // Create a DoubleAnimation for the X-axis
            DoubleAnimation animationX = new DoubleAnimation
            {
                To = mousePosition.X,  // The target X position
                Duration = TimeSpan.FromSeconds(1), // Duration of the animation (adjust as needed)
                EasingFunction = new QuadraticEase() // You can choose different easing functions
            };
            
            DoubleAnimation animationY= new DoubleAnimation
            {
                To = mousePosition.Y,  // The target X position
                Duration = TimeSpan.FromSeconds(1), // Duration of the animation (adjust as needed)
                EasingFunction = new QuadraticEase() // You can choose different easing functions
            };


            // Update the table's X position gradually using the animation
            TableRectangle.BeginAnimation(Canvas.LeftProperty, animationX);
            TableRectangle.BeginAnimation(Canvas.TopProperty, animationY);

            // Update the UI to reflect the new position
            UpdateUI();
        }
        private void MoveAxisClick(object sender, RoutedEventArgs e)
        {
            string axis = Regex.Replace($"{sender}", "[^XYZ]", "");
            Console.WriteLine(axis);
            foreach (var engine in _engines)
            {
                if (engine.MoveAxis(axis, _table, _sliders, 10, TableRectangle))
                {
                    break;
                };
            }
            UpdateUI();
        }
        private void UpdateUI()
        {
            // Update your UI elements with the simulated positions
            // For example, you can set labels or text blocks with the current positions
            LabelXPosition.Content = $"X: {_table.PositionX}";
            LabelYPosition.Content = $"Y: {_table.PositionY}";
            LabelZPosition.Content = $"Z: {_table.PositionZ}";
            
            // Update the range labels with the corresponding values (e.g., 0-100 as an example)
            LabelXRange.Content = "X Range: 0-100";
            LabelYRange.Content = "Y Range: 0-100";
            LabelZRange.Content = "Z Range: 0-100";
        }

    }
}