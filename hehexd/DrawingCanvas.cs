using hehexd.Commands;
using hehexd.composite;
using hehexd.Shapes;
using hehexd.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace hehexd
{
    public class DrawingCanvas
    {
        private Canvas myCanvas;
        private AbstractTool activeTool = new RectangleTool();
        private List<IRCommand> history = new List<IRCommand>();
        private ICommand tempcommand;
        //private ShapeTree shapetree;
        private List<AbstractFigure> figures = new List<AbstractFigure>();
        private bool ShapeExists;
        private AbstractFigure figure;

        public DrawingCanvas(Canvas myCanvas)
        {
            this.myCanvas = myCanvas;
        }

        public void execute(ICommand command)
        {
            if (history.Contains(tempcommand) || tempcommand == null) { }
            else
            //tempcommand.Delete(this);
            command.Execute(this);
            tempcommand = command;
            if (command is IRCommand)
            {
                history.Add((IRCommand)command);
                figures.Add(command.returnshape());
            }
        }

        public void SetActiveTool(AbstractTool tool)
        {
            activeTool = tool;
        }

        public void mouseEnter(Point start)
        {
            ShapeExists = false;
            AbstractFigure af = FindFigure(start);
            activeTool.setBeginPoint(af, start);
            if (af != null)
            activeTool.setShape(af.rChild()); //todo: get rid of setShape
        }

        public void mouseOther(Point start, Point end, bool drag)
        {
            if (activeTool.PointChanged(end))
            {
                if (activeTool is IToolNeedsShape && ShapeExists != true)
                {
                    ShapeExists = true;
                    UIElement newShape = ((IToolNeedsShape)activeTool).getShape();  //activetool.setShape(dat)
                    activeTool.setShape(newShape);
                    myCanvas.Children.Add(newShape); //canvas.add(dat)
                }
                //figure.setPoints(start, end);
                //else
                //{
                    //figure = FindFigure(end);
                    //if(figure != null)
                    //{
                //        //foreach (UIElement child in myCanvas.Children)
                //        //{
                //        //    Point s = figure.rStart();
                //        //    double x = Convert.ToDouble(child.GetValue(Canvas.LeftProperty));
                //        //    if (s.X == x)
                //        //    {
                        //activeTool.setShape(figure.rChild());
                          ///figure.setPoints(start, end);
                //        //        break;
                //        ////    }
                //        //}
                //    }
                //}
                ICommand ic = activeTool.getCommand(end, drag);
                if (ic != null) execute(ic);
            }
        }

        public Canvas GetCanvas()
        {
            return myCanvas;
        }

        public AbstractFigure FindFigure(Point start)
        {
            foreach(AbstractFigure f in figures)
            {
                if (f.find(start) != null) return f;
            }
            return null;
        }
    }
}
