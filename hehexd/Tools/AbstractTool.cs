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

        public abstract ICommand getCommand(Point end, bool temporary);

        public void setBeginPoint(Point start)
        {
            this.start = start;
        }

        public bool PointChanged(Point end)
        {
            return start != end;
        }
    }
}
