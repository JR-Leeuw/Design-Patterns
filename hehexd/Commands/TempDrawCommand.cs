using hehexd.Commands;
using hehexd.Shapes;

namespace hehexd.Tools
{
    public class TempDrawCommand : ICommand
    {

        private AbstractFigure shape;


        public TempDrawCommand(AbstractFigure shape)
        {
            this.shape = shape;
        }

        public void Execute(DrawingCanvas dc)
        {
            //do draw shit (gooi in lijs en redraw canvas)
            dc.GetCanvas().Children.Add(shape.GetObject());
        }

        public void Delete(DrawingCanvas dc)
        {
            dc.GetCanvas().Children.RemoveAt(dc.GetCanvas().Children.Count - 1);
        }
    }
}