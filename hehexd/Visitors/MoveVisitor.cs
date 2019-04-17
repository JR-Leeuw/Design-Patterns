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
    class MoveVisitor : IVisitor
    {
        string command;
        Point a, b;

        public MoveVisitor(string s, Point a, Point b)
        {
            this.command = s;
            this.a = a;
            this.b = b;
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
            shape.Drag(command, a, b);
        }

        public void visit(EllipseShape shape)
        {
            shape.Drag(command, a, b);
        }

        public void visit(BaseFigure BaseFigure)
        {
            BaseFigure.Drag(command, a, b);
        }
    }
}
