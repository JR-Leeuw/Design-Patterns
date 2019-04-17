using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.Shapes;

namespace hehexd.Commands
{
    class SaveCommand : IRCommand
    {
        public void Execute(DrawingCanvas dc)
        {
            //SaveVisitor();
        }

        public void ReExecute(DrawingCanvas dc)
        {
            throw new NotImplementedException();
        }

        public AbstractFigure returnshape()
        {
            throw new NotImplementedException();
        }

        public void Unexecute(DrawingCanvas dc)
        {
            throw new NotImplementedException();
        }
    }
}
