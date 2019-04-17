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
    public class EllipseShape : AbstractFigure
    {
        public EllipseShape(Point start, Point end, UIElement child)
        {
            this.start = start;
            this.end = end;
            this.child = child;
        }

        public override Shape GetObject()
        {
            Ellipse newEllipse = new Ellipse();
            //{
            //    Fill = Brushes.Black,
            //    Stroke = Brushes.White,
            //    StrokeThickness = 4
            //};
            //if (end.X >= start.X)
            //{
            //    newEllipse.SetValue(Canvas.LeftProperty, start.X);
            //    newEllipse.Width = end.X - start.X;
            //}
            //else
            //{
            //    newEllipse.SetValue(Canvas.LeftProperty, end.X);
            //    newEllipse.Width = start.X - end.X;
            //}

            //if (end.Y >= start.Y)
            //{
            //    newEllipse.SetValue(Canvas.TopProperty, start.Y);
            //    newEllipse.Height = end.Y - start.Y;
            //}
            //else
            //{
            //    newEllipse.SetValue(Canvas.TopProperty, end.Y);
            //    newEllipse.Height = start.Y - end.Y;
            //}
            return newEllipse;
        }

        public override void accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }
}