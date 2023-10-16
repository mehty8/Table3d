using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Table3d;

public class EngineY : IEngine
{
    public int Speed { get; set; }
    
    public bool MoveAxis(string axis, Table table, List<Slider> sliders,  int multiplier, Rectangle rectangle)
    {
        if (axis.Equals("Y"))
        {
            Slider ySlider = sliders[1];
            Speed = (int)ySlider.Value * multiplier;
            table.PositionY += Speed;
            Canvas.SetTop(rectangle, table.PositionY);
            return true;
        }
        return false;
    }
}