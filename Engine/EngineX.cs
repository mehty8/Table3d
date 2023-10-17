using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Table3d;

public class EngineX : IEngine
{

    public int Speed { get; set; }
    
    public bool MoveAxis(string axis, Table table, List<Slider> sliders,  int multiplier, Rectangle rectangle)
    {
        if (axis.Equals("X"))
        {
            Slider xSlider = sliders.First(slider => slider.Name.Equals("XSlider"));
            Speed = (int)xSlider.Value * multiplier;
            table.PositionX += Speed;
            Canvas.SetLeft(rectangle, table.PositionX);
            return true;
        }
        return false;
    }
}