using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.Shapes;
using hehexd.Visitors;

namespace hehexd.Commands
{
    class DeleteCommand : IRCommand
    {
        private AbstractFigure shape;

        public DeleteCommand(AbstractFigure shape)
        {
            this.shape = shape;
        }

        public void Execute(DrawingCanvas dc)
        {
            dc.GetCanvas().Children.Remove(shape.rChild());
        }

        public void ReExecute(DrawingCanvas dc)
        {
            dc.GetCanvas().Children.Remove(shape.rChild());
        }

        public AbstractFigure returnshape()
        {
            return shape;
        }

        public void Unexecute(DrawingCanvas dc)
        {
            dc.GetCanvas().Children.Insert(shape.getindex(), shape.rChild());
        }
    }
}
