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
    public class ResizeCommand : IRCommand
    {
        //protected Point start;
        //protected Point end;
        private AbstractFigure figure;

        public ResizeCommand(AbstractFigure figure)
        {
            this.figure = figure;
        }

        public void Delete(DrawingCanvas dc)
        {

        }

        public void Execute(DrawingCanvas dc)
        {
            //figure.accept(new ResizeVisitor());
        }

        public void ReExecute(DrawingCanvas dc)
        {
            figure.accept(new ResizeVisitor("r"));
        }

        public AbstractFigure returnshape()
        {
            throw new NotImplementedException();
        }

        public void Unexecute(DrawingCanvas dc)
        {
            figure.accept(new ResizeVisitor("u"));
        }

        AbstractFigure ICommand.returnshape()
        {
            return figure;
        }
    }
}
