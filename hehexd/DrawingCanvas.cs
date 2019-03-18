﻿using hehexd.Commands;
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

namespace hehexd
{
    public class DrawingCanvas
    {
        private Canvas myCanvas;
        private AbstractTool activeTool = new RectangleTool();
        private List<IRCommand> history = new List<IRCommand>();
        private ICommand tempcommand;
        private ShapeTree shapetree;
        private List<AbstractFigure> figures = new List<AbstractFigure>();
        private bool ShapeExists;

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

        }

        public void SetActiveTool(AbstractTool tool)
        {
            activeTool = tool;
        }

        public void mouseEnter(Point start)
        {
            ShapeExists = false;
            activeTool.setBeginPoint(FindFigure(start), start);

        }

        public void mouseOther(Point end, bool drag)
        {
            if (activeTool.PointChanged(end))
            {
                if (activeTool.NeedsShape() && ShapeExists != true) 
                {
                    ShapeExists = true;
                    //maak leeg UIElment maakt mij niet uit deze zal overschreden worden
                    //canvas.add(dat)
                    //activetool.setShape(dat)
                }
                ICommand ic = activeTool.getCommand(end, drag);
                if (ic != null)
                    execute(ic);
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
