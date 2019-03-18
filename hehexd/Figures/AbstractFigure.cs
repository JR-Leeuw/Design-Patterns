using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace hehexd.Shapes
{
    public abstract class AbstractFigure
    {
        protected Point start;
        protected Point end;
        protected UIElement child;

        public abstract Shape GetObject();

        public void Drag()
        {
            double posx = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
            double posy = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
            double nposx = (start.X - end.X);
            double nposy = (start.Y - end.Y);
            child.SetValue(Canvas.LeftProperty, posx - nposx);
            child.SetValue(Canvas.TopProperty, posy - nposy);
            //child.SetValue(Canvas.StyleProperty, Brushes.Blue);
        }

        public AbstractFigure find(Point punt)
        {
            if ((start.X < punt.X && end.X > punt.X && start.Y < punt.Y && end.Y > punt.Y))
            {
                return this;
            }
            else
            {
                return null;
            }
        }
    }
}
