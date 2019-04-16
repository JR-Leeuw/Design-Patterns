using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using hehexd.composite;
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

        public void visit(AbstractFigure figure)
        {
            figure.Drag(command, a, b);
        }

        public void visit(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
