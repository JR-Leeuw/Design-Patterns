using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.Commands;

namespace hehexd.Tools
{
    public class DragTool : AbstractTool
    {
        public override ICommand getCommand(Point end, bool temporary)
        {
            
            DragCommand d = new DragCommand(this.start, end);
            return d;
        }
    }
}
