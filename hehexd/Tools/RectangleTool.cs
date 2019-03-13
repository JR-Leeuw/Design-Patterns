using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.Commands;

namespace hehexd.Tools
{
    public class RectangleTool : AbstractTool
    {
        public override ICommand getCommand(Point end, bool temporary)
        {
            //if (end.X >= start.X)
            //{
            //    newRectangle.SetValue(Canvas.LeftProperty, start.X);
            //    newRectangle.Width = end.X - start.X;
            //}
            //else
            //{
            //    newRectangle.SetValue(Canvas.LeftProperty, end.X);
            //    newRectangle.Width = start.X - end.X;
            //}

            //if (end.Y >= start.Y)
            //{
            //    newRectangle.SetValue(Canvas.TopProperty, start.Y - 50);
            //    newRectangle.Height = end.Y - start.Y;
            //}
            //else
            //{
            //    newRectangle.SetValue(Canvas.TopProperty, end.Y - 50);
            //    newRectangle.Height = start.Y - end.Y;
            //}
            return new DrawCommand(new RectangleShape(this.start, end));
        }
    }
}
