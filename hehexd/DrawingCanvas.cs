using hehexd.Commands;
using hehexd.composite;
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
        private List<IRCommand> history = new List<IRCommand>();
        private ICommand tempcommand;
        private ShapeTree shapetree;

        public DrawingCanvas(Canvas myCanvas)
        {
            this.myCanvas = myCanvas;
        }

        public void execute(ICommand command)
        {
            if (history.Contains(tempcommand) || tempcommand == null) { }
            else
            tempcommand.Delete(this);
            command.Execute(this);
            tempcommand = command;
            if (command is IRCommand)
            history.Add((IRCommand)command);
        }

        public void repaint()
        {
            //myCanvas.Children.Clear();
            //foreach (IRCommand command in history)
            //{
            //    command.Execute(this);
            //}
        }

        public void SetActiveTool(AbstractTool tool)
        {
            activeTool = tool;
        }

        public void mouseEnter(Point start, UIElement child)
        {
            activeTool.setBeginPoint(start, child);
        }

        public void mouseOther(Point end, bool drag)
        {
            if (activeTool.PointChanged(end))
            {
                ICommand ic = activeTool.getCommand(end, drag);
                if (ic != null)
                    execute(ic);
            }
        }

        public Canvas GetCanvas()
        {
            return myCanvas;
        }
    }
}
