using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.Commands;
using System.Windows.Media;
using System.Windows.Shapes;
using hehexd.Strategy;

namespace hehexd.Tools
{
    public class RectangleTool : AbstractTool, IToolNeedsShape
    {
        public override ICommand getCommand(Point end, bool temporary)
        {
             if (temporary)
            {
                return new TempDrawCommand(new RectangleShape(this.start, end, child));
            }
            else
            {
                return new DrawCommand(new RectangleShape(this.start, end, child));
            }
        }

        public UIElement getShape()
        {
            //return new Rectangle() { Width = 0, Height = 0, Fill = Brushes.Black, Stroke = Brushes.White, StrokeThickness = 1, };
            return new DrawRectangle().doOperation();
        }
    }
}
