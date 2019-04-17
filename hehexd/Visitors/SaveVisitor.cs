using hehexd.composite;
using hehexd.Figures;
using hehexd.SaveFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd.Visitors
{
    class SaveVisitor : IVisitor
    {
        private Save saver = new SaveFile.Save();
        List<IComponent> C = new List<IComponent>();
        public SaveVisitor(List<IComponent> c)
        {
            this.C = c;
        }

        public void visit(RectangleShape shape)
        {
            saver.FileSave(shape.GetChild());
        }

        public void visit(EllipseShape shape)
        {
            saver.FileSave(shape.GetChild());
        }

        public void visit(Group group)
        {
            foreach (IComponent figure in C)
            {
                figure.accept(this);
            }
        }

        public void visit(BaseFigure BaseFigure)
        {
            saver.FileSave(BaseFigure.GetChild());
        }
    }
}
