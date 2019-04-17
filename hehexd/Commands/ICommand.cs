using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.Shapes;

namespace hehexd
{
    public interface ICommand
    {
        void Execute(DrawingCanvas dc);
        AbstractFigure returnshape();
    }
}
