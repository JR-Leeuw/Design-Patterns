using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.composite;
using hehexd.Shapes;

namespace hehexd.Visitors
{
    class MoveVisitor : IVisitor
    {
        string command;

        public MoveVisitor(string s)
        {
            this.command = s;
        }

        public void visit(AbstractFigure figure)
        {
            figure.Drag(command);
        }

        public void visit(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
