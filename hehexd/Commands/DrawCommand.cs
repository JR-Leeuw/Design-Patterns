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
    public class DrawCommand : IRCommand
    {

        private AbstractFigure shape;
        bool exists = true;


        public DrawCommand(AbstractFigure shape)
        {
            this.shape = shape;
        }

        public void Execute(DrawingCanvas dc)
        {
            if (exists == false)
            {
                shape.accept(new DrawVisitor());

            }
            else { }
        }

        public void Unexecute(DrawingCanvas dc)
        {
            exists = false;
            dc.GetCanvas().Children.Remove(shape.rChild());
        }

        public AbstractFigure returnshape()
        {
            return shape;
        }

        public void ReExecute(DrawingCanvas dc)
        {
            dc.GetCanvas().Children.Insert(shape.getindex(), shape.rChild());
        }
    }
}
