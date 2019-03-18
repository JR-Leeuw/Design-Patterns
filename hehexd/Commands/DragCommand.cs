using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace hehexd.Commands
{
    public class DragCommand : ICommand
    {
        protected Point start;
        protected Point end;
        protected UIElement child;
        double posx, posy;

        public DragCommand(Point start, Point end, UIElement child)
        {
            this.start = start;
            this.end = end;
            this.child = child;
        }

        public void Delete(DrawingCanvas dc)
        {
            
        }

        public void Execute(DrawingCanvas dc)
        {
            posx = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
            posy = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
            double nposx = (start.X - end.X);
            double nposy = (start.Y - end.Y);
            child.SetValue(Canvas.LeftProperty, posx - nposx);
            child.SetValue(Canvas.TopProperty, posy - nposy);
            //child.SetValue(Canvas.StyleProperty, Brushes.Blue);
        }
    }
}
