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
        int hzindex = 0;
        Size size;
        double posx, posy, width, hight, xright, ybottom;

        public DragCommand(Point start, Point end)
        {
            this.start = start;
            this.end = end;
        }

        public void Delete(DrawingCanvas dc)
        {
            
        }

        public void Execute(DrawingCanvas dc)
        {
            UIElement child = dc.GetCanvas().Children[0];
            for (int i = dc.GetCanvas().Children.Count - 1; i > -1; i--)
            {
                child = dc.GetCanvas().Children[i];
                posx = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
                posy = Convert.ToDouble(child.GetValue(Canvas.TopProperty));
                size = child.RenderSize;
                hight = size.Height;
                width = size.Width;
                xright = posx + width;
                ybottom = posy + hight;

                if ((start.X > posx && start.X < xright && start.Y > posy && start.Y < ybottom))
                {
                    double nposx = (start.X - end.X);
                    double nposy = (start.Y - end.Y);
                    child.SetValue(Canvas.LeftProperty, posx - nposx);
                    child.SetValue(Canvas.TopProperty, posy - nposy);
                    //child.SetValue(Canvas.StyleProperty, Brushes.Blue);
                }
            }
        }
    }
}
