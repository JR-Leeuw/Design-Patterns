using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.composite;
using hehexd.Shapes;

namespace hehexd.Visitors
{
    class ResizeVisitor : IVisitor
    {
        string command;

        public ResizeVisitor(string s)
        {
            this.command = s;
        }

        public void visit(AbstractFigure figure)
        {
            figure.Resize(command);
        }

        public void visit(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
