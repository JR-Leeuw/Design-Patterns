using hehexd.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd.Commands
{
    public class DrawCommand : ICommand
    {

        private AbstractShape shape;

        public DrawCommand(AbstractShape shape)
        {
            this.shape = shape;
        }

        public void Execute(DrawingCanvas dc)
        {
            //do draw shit (gooi in lijs en redraw canvas)
            dc.GetCanvas().Children.Add(shape.GetObject());
        }
    }
}
