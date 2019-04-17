using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using hehexd.Shapes;
using hehexd.Visitors;

namespace hehexd.Commands
{
    class PaintCommand : IRCommand
    {
        private AbstractFigure shape;
        private Color c;

        public PaintCommand(AbstractFigure shape)
        {
            this.shape = shape;
        }

        public void Execute(DrawingCanvas dc)
        {
            c = dc.GetColor();
            shape.accept(new PaintVisitor(c));
        }

        public void ReExecute(DrawingCanvas dc)
        {
            shape.accept(new PaintVisitor(c));
        }

        public AbstractFigure returnshape()
        {
            return shape;
        }

        public void Unexecute(DrawingCanvas dc)
        {
            throw new NotImplementedException();
        }
    }
}
