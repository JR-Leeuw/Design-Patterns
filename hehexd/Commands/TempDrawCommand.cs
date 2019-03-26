using hehexd.Commands;
using hehexd.Shapes;
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
            figure.Drawshape();
        }

        public void Delete(DrawingCanvas dc)
        {
            //dc.GetCanvas().Children.RemoveAt(dc.GetCanvas().Children.Count - 1);
        }

        AbstractFigure ICommand.returnshape()
        {
            return figure;
        }
    }
}