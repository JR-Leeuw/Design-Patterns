using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.composite;
using hehexd.Shapes;

namespace hehexd.Visitors
{
    class DrawVisitor : IVisitor
    {
        public DrawVisitor() { }

        public void visit(AbstractFigure figure)
        {
            figure.Drawshape();
        }

        public void visit(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
