using hehexd.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace hehexd.Strategy
{
    public class EllipseToString : IToStringStrategy
    {
        public string doOperation()
        {
            return "Ellipse";
        }
    }

    public class DrawEllipse : IDrawStrategy
    {
        public UIElement doOperation()
        {
            return new Ellipse() { Width = 0, Height = 0, Fill = Brushes.Black, Stroke = Brushes.White, StrokeThickness = 1, };
        }
    }
}
