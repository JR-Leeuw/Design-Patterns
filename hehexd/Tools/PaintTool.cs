using hehexd.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hehexd.Tools
{
    class PaintTool : AbstractTool
    {
        public override ICommand getCommand(Point end, bool temporary)
        {
            if (abstractFigure != null)
            {
                return new PaintCommand(this.abstractFigure);
            }
            else
                return null;
        }
    }
}
