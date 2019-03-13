using hehexd.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace hehexd
{
    public class DrawingCanvas
    {
        private Canvas myCanvas;
        private AbstractTool activeTool = new RectangleTool();
        private List<ICommand> history = new List<ICommand>();

        public DrawingCanvas(Canvas myCanvas)
        {
            this.myCanvas = myCanvas;
        }

        public void execute(ICommand command)
        {
            command.Execute(this);
            history.Add(command);
        }

        public void repaint()
        {
            //myCanvas.repaint();
        }

        public void SetActiveTool(AbstractTool tool)
        {
            activeTool = tool;
        }

        public void mouseEnter(Point start)
        {
            activeTool.setBeginPoint(start);
        }

        public void mouseOther(Point end, bool drag)
        {
            if (activeTool.PointChanged(end))
                execute(activeTool.getCommand(end, drag));
        }

        public Canvas GetCanvas()
        {
            return myCanvas;
        }
    }
}
