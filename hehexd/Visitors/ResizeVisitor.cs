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

        public void visit(AbstractFigure figure)
        {
            figure.Resize(command, start, end);
        }

        public void visit(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
