using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private int _positionX;
        private int _positionY;
        private int _positionZ;
        public MainWindow()
        {
            
            InitializeComponent();
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
        
        private void XSpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the new speed value for the X-axis
            double xSpeed = XSpeedSlider.Value;
            // Update the speed setting for the X-axis as needed
        }

        private void YSpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the new speed value for the Y-axis
            double ySpeed = YSpeedSlider.Value;
            // Update the speed setting for the Y-axis as needed
        }

        private void ZSpeedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // Get the new speed value for the Z-axis
            double zSpeed = ZSpeedSlider.Value;
            // Update the speed setting for the Z-axis as needed
        }


        
        private void MoveXAxis_Click(object sender, RoutedEventArgs e)
        {
            // Get the current X-axis speed setting from XSpeedSlider
            double xSpeed = XSpeedSlider.Value;

            // Calculate the step size based on the speed setting
            int stepSize = (int)xSpeed * 10; // Adjust the multiplier as needed

            // Simulate movement along the X-axis using the adjusted step size
            _positionX += stepSize;
            UpdateUI();

            // Update the position of the rectangle on the Canvas
            Canvas.SetLeft(TableRectangle, _positionX);
        }

        private void MoveYAxis_Click(object sender, RoutedEventArgs e)
        {
            // Get the current X-axis speed setting from XSpeedSlider
            double ySpeed = YSpeedSlider.Value;

            // Calculate the step size based on the speed setting
            int stepSize = (int)ySpeed * 10; // Adjust the multiplier as needed

            // Simulate movement along the X-axis using the adjusted step size
            _positionY += stepSize;
            UpdateUI();

            // Update the position of the rectangle on the Canvas
            Canvas.SetTop(TableRectangle, _positionY);
        }

        private void MoveZAxis_Click(object sender, RoutedEventArgs e)
        {
            // Simulate movement along the Z-axis
            // Get the current X-axis speed setting from XSpeedSlider
            double zSpeed = ZSpeedSlider.Value;

            // Calculate the step size based on the speed setting
            int stepSize = (int)zSpeed * 10; // Adjust the multiplier as needed

            // Simulate movement along the X-axis using the adjusted step size
            _positionZ += stepSize;
            UpdateUI();

            // Update the position of the rectangle on the Canvas
            Canvas.SetLeft(TableRectangle, _positionZ);
        }
        
        private void UpdateUI()
        {
            // Update your UI elements with the simulated positions
            // For example, you can set labels or text blocks with the current positions
            LabelXPosition.Content = $"X: {_positionX}";
            LabelYPosition.Content = $"Y: {_positionY}";
            LabelZPosition.Content = $"Z: {_positionZ}";
            
            // Update the range labels with the corresponding values (e.g., 0-100 as an example)
            LabelXRange.Content = $"X Range: 0-100";
            LabelYRange.Content = $"Y Range: 0-100";
            LabelZRange.Content = $"Z Range: 0-100";
        }

    }
}