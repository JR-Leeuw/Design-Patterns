using hehexd.Shapes;
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
            //dc.GetCanvas().Children.Add(shape.GetObject());
        }

        public void Unexecute(DrawingCanvas dc)
        {
            //dc.GetCanvas().Children.Remove(shape.GetObject());
        }

        public void Delete(DrawingCanvas dc)
        {
            dc.GetCanvas().Children.RemoveAt(dc.GetCanvas().Children.Count - 1);
        }

        public AbstractFigure returnshape()
        {
            return shape;
        }
    }
}
