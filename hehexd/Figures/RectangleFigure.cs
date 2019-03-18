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
            Rectangle newRectangle = new Rectangle() {
                Fill = Brushes.Black,
                Stroke = Brushes.White,
                StrokeThickness  = 4
            };
            if (end.X >= start.X)
            {
                newRectangle.SetValue(Canvas.LeftProperty, start.X);
                newRectangle.Width = end.X - start.X;
            }
            else
            {
                newRectangle.SetValue(Canvas.LeftProperty, end.X);
                newRectangle.Width = start.X - end.X;
            }

            if (end.Y >= start.Y)
            {
                newRectangle.SetValue(Canvas.TopProperty, start.Y);
                newRectangle.Height = end.Y - start.Y;
            }
            else
            {
                newRectangle.SetValue(Canvas.TopProperty, end.Y);
                newRectangle.Height = start.Y - end.Y;
            }
            return newRectangle;
        }
    }
}
