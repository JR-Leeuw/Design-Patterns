using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using hehexd.composite;
using hehexd.Figures;

namespace hehexd.Visitors
{
    class PaintVisitor : IVisitor
    {
        Color c;
        public PaintVisitor(Color c)
        {
            this.c = c;
        }

        public void visit(RectangleShape shape)
        {
            shape.Paint(c);
        }

        public void visit(EllipseShape shape)
        {
            shape.Paint(c);
        }

        public void visit(Group group)
        {
            List<IComponent> figures = group.returnFigures();
            foreach (IComponent figure in figures)
            {
                figure.accept(this);
            }
        }

        public void visit(BaseFigure BaseFigure)
        {
            BaseFigure.Paint(c);
        }
    }
}
