using hehexd.Commands;
using hehexd.Shapes;
using hehexd.Visitors;
using System.Windows;
using System.Windows.Controls;

namespace hehexd.Tools
{
    public class TempDrawCommand : ICommand
    {

        private AbstractFigure figure;


        public TempDrawCommand(AbstractFigure figure)
        {
            this.figure = figure;
        }

        public void Execute(DrawingCanvas dc)
        {
            figure.accept(new DrawVisitor());
        }

        AbstractFigure ICommand.returnshape()
        {
            return figure;
        }
    }
}