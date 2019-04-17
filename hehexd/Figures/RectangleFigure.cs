using hehexd.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using hehexd.Visitors;

namespace hehexd
{
    public class RectangleShape : AbstractFigure
    {
        public RectangleShape(Point start, Point end, UIElement child)
        {
            this.start = start;
            this.end = end;
            this.child = child;
        }

        public override Shape GetObject()
        {
            Rectangle newRectangle = new Rectangle(); //{
            //    Fill = Brushes.Black,
            //    Stroke = Brushes.White,
            //    StrokeThickness  = 4
            //};
            return newRectangle;
        }

        public override void accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}
