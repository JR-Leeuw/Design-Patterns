using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using hehexd.Commands;
namespace hehexd.Tools
{
    class DeleteTool : AbstractTool
    {
        public override ICommand getCommand(Point end, bool temporary)
        {
            if (abstractFigure != null)
            {
                return new DeleteCommand(this.abstractFigure);
            }
            else
                return null;
        }
    }
}
