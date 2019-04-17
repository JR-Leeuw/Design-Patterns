using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using hehexd.composite;
using hehexd.Figures;
using hehexd.Shapes;

namespace hehexd.Visitors
{
    class ResizeVisitor : IVisitor
    {
        string command;
        Point start, end;

        public ResizeVisitor(string s, Point start, Point end)
        {
            this.command = s;
            this.start = start;
            this.end = end;
        }

        public void visit(Group group)
        {
            List<IComponent> figures = group.returnFigures();
            foreach (IComponent figure in figures)
            {
                figure.accept(this);
            }
        }

        public void visit(RectangleShape shape)
        {
            shape.Resize(command, start, end);
        }

        public void visit(EllipseShape shape)
        {
            shape.Resize(command, start, end);
        }

        public void visit(BaseFigure BaseFigure)
        {
            BaseFigure.Resize(command, start, end);
        }
    }
}
