using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Table3d;

public interface IEngine
{
    public int Speed { get; set; }

    public bool MoveAxis(string axis, Table table, List<Slider> sliders, int multiplier, Rectangle rectangle);
}