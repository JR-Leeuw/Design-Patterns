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
    public class TempDragCommand : IRCommand
    {
 
        private AbstractFigure figure;

        public TempDragCommand(AbstractFigure figure)
        {
            this.figure= figure;
        }

        public void Delete(DrawingCanvas dc)
        {
            
        }

        public void Execute(DrawingCanvas dc)
        {
            figure.Drag();
        }

        public void Unexecute(DrawingCanvas dc)
        {
            throw new NotImplementedException();
        }

        AbstractFigure ICommand.returnshape()
        {
            return figure;
        }
    }
}
