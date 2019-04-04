using hehexd.composite;
using hehexd.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd.Visitors
{
    public interface IVisitor
    {
        void visit(AbstractFigure figure);
    }
}
