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
        protected UIElement child;

        public abstract ICommand getCommand(Point end, bool temporary);

        public void setBeginPoint(Point start, UIElement child)
        {
            this.start = start;
            this.child = child;
        }

        public bool PointChanged(Point end)
        {
            return start != end;
        }
    }
}
