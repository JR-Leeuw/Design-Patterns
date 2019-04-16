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
        private AbstractFigure figure;
        private Point start, end;

        public TempResizeCommand(AbstractFigure figure)
        {
            this.figure = figure;
            this.start = figure.rBStart();
            this.end = figure.rEnd();
        }

        public void Delete(DrawingCanvas dc)
        {

        }

        public void Execute(DrawingCanvas dc)
        {
            figure.accept(new ResizeVisitor("e", start, end));
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
