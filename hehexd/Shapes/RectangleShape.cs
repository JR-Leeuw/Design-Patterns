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
    public class RectangleShape : AbstractShape
    {
        public RectangleShape(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public override void Draw(Canvas canvas)
        {
            Rectangle rect = new Rectangle();
            //set eigenschappen Rectangle
            canvas.Children.Add(rect);
        }

        public override Shape GetObject()
        {
            Rectangle rect = new Rectangle() {
                Fill = Brushes.Black
            };
            rect.SetValue(Canvas.TopProperty, start.Y);
            rect.SetValue(Canvas.LeftProperty, start.X);
            rect.Width = end.X - start.X;
            rect.Height = end.Y - start.Y;
            return rect;
        }
    }
}
