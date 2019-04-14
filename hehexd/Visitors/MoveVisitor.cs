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
        public MoveVisitor() { }

        public void visit(AbstractFigure figure)
        {
            figure.Drag();
        }

        public void visit(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
