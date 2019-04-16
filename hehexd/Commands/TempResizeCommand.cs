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
    public class TempResizeCommand : IRCommand
    {
        //protected Point start;
        //protected Point end;
        private AbstractFigure figure;

        public TempResizeCommand(AbstractFigure figure)
        {
            this.figure = figure;
        }

        public void Delete(DrawingCanvas dc)
        {

        }

        public void Execute(DrawingCanvas dc)
        {
            figure.accept(new ResizeVisitor("e"));
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

        AbstractFigure ICommand.returnshape()
        {
            return figure;
        }
    }
}
