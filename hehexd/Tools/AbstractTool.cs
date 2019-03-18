using hehexd.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hehexd.Tools
{
    public abstract class AbstractTool
    {
        protected Point start;
        protected AbstractFigure abstractFigure;
        protected UIElement child;

        public abstract ICommand getCommand(Point end, bool temporary);
        public abstract bool NeedsShape();

        public void setBeginPoint(AbstractFigure abstractFigure, Point start)
        {
            this.abstractFigure = abstractFigure;
            this.start = start;
        }

        public bool PointChanged(Point end)
        {
            return start != end;
        }

        public void setShape(UIElement child)
        {
            this.child = child;
        }
    }
}
