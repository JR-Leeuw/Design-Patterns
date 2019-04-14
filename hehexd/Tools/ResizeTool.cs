using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.Commands;

namespace hehexd.Tools
{
    public class ResizeTool : AbstractTool
    {
        public override ICommand getCommand(Point end, bool temporary)
        {
            if (abstractFigure != null)
            {
                if (temporary)
                {
                    return new TempResizeCommand(this.abstractFigure);
                }
                else
                {
                    return new ResizeCommand(this.abstractFigure);
                }
                
            }
            else
                return null;
        }
    }
}
