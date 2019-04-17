using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.composite;
using hehexd.Figures;
using hehexd.Shapes;

namespace hehexd.Visitors
{
    class DrawVisitor : IVisitor
    {
        public DrawVisitor() { }

        public void visit(RectangleShape shape)
        {
            shape.Drawshape();
        }

        public void visit(EllipseShape shape)
        {
            shape.Drawshape();
        }

        public void visit(Group group)
        {
            throw new NotImplementedException();
        }

        public void visit(BaseFigure BaseFigure)
        {
            BaseFigure.Drawshape();
        }
    }
}
