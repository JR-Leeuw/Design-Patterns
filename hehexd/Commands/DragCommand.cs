using hehexd.Shapes;
using hehexd.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace hehexd.Commands
{
    public class DragCommand : IRCommand
    {

        private AbstractFigure shape;


        public DragCommand(AbstractFigure shape)
        {
            this.shape = shape;
        }

        public void Execute(DrawingCanvas dc)
        {
            shape.accept(new MoveVisitor("e"));
        }

        public void Unexecute(DrawingCanvas dc)
        {
            shape.accept(new MoveVisitor("u"));
        }

        public void Delete(DrawingCanvas dc)
        {
            dc.GetCanvas().Children.RemoveAt(dc.GetCanvas().Children.Count - 1);
        }

        public AbstractFigure returnshape()
        {
            return shape;
        }

        public void ReExecute(DrawingCanvas dc)
        {
            shape.accept(new MoveVisitor("r"));
        }
    }
}
