using hehexd.Commands;
using hehexd.composite;
using hehexd.Shapes;
using hehexd.Tools;
using hehexd.SaveFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using hehexd.Visitors;

namespace hehexd
{
    public class DrawingCanvas
    {
        private Canvas myCanvas;
        private Save saver = new SaveFile.Save();
        private AbstractTool activeTool = new RectangleTool();
        private List<IRCommand> history = new List<IRCommand>();
        private ICommand tempcommand;
        //private ShapeTree shapetree;
        private List<AbstractFigure> figures = new List<AbstractFigure>();
        private bool ShapeExists;
        private AbstractFigure figure;
        private Group gfigures = new Group();
        public Group activeGroup;
        private int Cindex = -1;

        private Color sc;

        private DrawingCanvas()
        {
           
        }

        private static DrawingCanvas instance = new DrawingCanvas();

        public static DrawingCanvas getinstance()
        {
            return instance;
        }

        public void execute(ICommand command)
        {
            if (command != null)
            {
                if (!command.ToString().Contains("Temp"))
                {
                    Cindex = Cindex + 1;
                    history_updater();
                    AbstractFigure shape = command.returnshape();
                    if (command.ToString().Contains("draw"))
                        shape.setindex(Cindex);
                    history.Add((IRCommand)command);
                    gfigures.add(command.returnshape());
                    figures.Add(shape);
                }
                command.Execute(this);
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
            {
                figure = FindFigure(start);
                figure.SetBaseStart(start);
            }

            if (activeTool.ToString().Contains("Delete") || activeTool.ToString().Contains("Paint"))
            {
                ICommand ic = activeTool.getCommand(new Point(0,0), false);
                execute(ic);
            }
        }

        public void mouseOther(Point start, Point end, bool temp)
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
                    
                if(activeTool.ToString().Contains("DragTool") && figure != null|| activeTool.ToString().Contains("ResizeTool") && figure != null)
                    figure.setPoints(start, end);
                ICommand ic = activeTool.getCommand(end, temp);
                if (ic != null) execute(ic);
            }
        }

        public Canvas GetCanvas()
        {
            return myCanvas;
        }

        public AbstractFigure FindFigure(Point start)
        {
            for (int i = figures.Count -1; i > -1; i--)
            {
                var f = figures[i];
                if (f.find(start) != null) return f;
            }
            return null;
        }

        public void Undo()
        {
            if (Cindex > -1)
            {
                IRCommand c = history[Cindex];
                c.Unexecute(this);
                Cindex = Cindex - 1;
            }
        }

        public void Redo()
        {
            if (Cindex < history.Count - 1)
            {
                Cindex = Cindex + 1;
                history[Cindex].ReExecute(this);
            }
        }

        public void Save()
        {
            List<IComponent> c = gfigures.returnFigures();
            //saver.FileSave(gfigures);
            gfigures.accept(new SaveVisitor(c));
        }

        public void Load()
        {
            List<UIElement> u = saver.LoadFile();
            foreach (UIElement ui in u)
            {
                bool shape = true;
                Point b = new Point(0, 0);
                Point c = new Point(0, 0);
                EllipseShape a = new EllipseShape(b, c, ui);
                RectangleShape aa = new RectangleShape(b, c, ui);
                if (ui.ToString().Contains("Ellipse")) { shape = true; }
                else if (ui.ToString().Contains("Rectangle")) { shape = false; }
                activeTool.setShape(ui);
                myCanvas.Children.Add(ui);
                if(shape)figures.Add(a);
                else figures.Add(aa);
            }
        }

        public void history_updater()
        {
            if (Cindex < history.Count)
            {
                for (int i = Cindex; i < history.Count;)
                {
                    history.RemoveAt(i);
                }
            }
        }

        public void SetColor(Color c)
        {
            sc = c;
        }

        public Color GetColor()
        {
            return sc;
        }

        public void setCanvas(Canvas myCanvas)
        {
            this.myCanvas = myCanvas;
        }
    }
}
