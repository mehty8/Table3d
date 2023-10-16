using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Table3d;

public class EngineZ : IEngine
{
    public int Speed { get; set; }
    
    public bool MoveAxis(string axis, Table table, List<Slider> sliders,  int multiplier, Rectangle rectangle)
    {
        if (axis.Equals("Z"))
        {
            Slider zSlider = sliders[2];
            Speed = (int)zSlider.Value * multiplier;
            table.PositionZ += Speed;
            Canvas.SetLeft(rectangle, table.PositionZ);
            return true;
        }
        return false;
    }
}