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
        public ResizeVisitor(){ }

        public void visit(AbstractFigure figure)
        {
            figure.Resize();
        }
    }
}
