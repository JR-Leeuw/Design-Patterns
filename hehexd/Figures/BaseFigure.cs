using hehexd.composite;
using hehexd.Shapes;
using hehexd.Strategy;
using hehexd.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace hehexd.Figures
{
    public class BaseFigure : AbstractFigure
    {
        public IDrawStrategy DrawStrategy;
        public IToStringStrategy ToStringStrategy;

        public BaseFigure(IToStringStrategy ToStringStrategy, IDrawStrategy DrawStrategy)
        {
            this.ToStringStrategy = ToStringStrategy;
            this.DrawStrategy = DrawStrategy;
        }

        public AbstractFigure SetVariables(Point start, Point end, UIElement child)
        {
            this.start = start;
            this.end = end;
            this.child = child;
            return this;
        }

        public override void accept(IVisitor visitor)
        {
            visitor.visit(this);
        }

        public static BaseFigure ReturnRectangleinstance()
        {
            return new BaseFigure(new RectangleToString(), new DrawRectangle());
        }

        public static BaseFigure ReturnEllipseinstance()
        {
            return new BaseFigure(new EllipseToString(), new DrawEllipse());
        }
        
        public override Shape GetObject()
        {
            throw new NotImplementedException();
        }
    }
}
