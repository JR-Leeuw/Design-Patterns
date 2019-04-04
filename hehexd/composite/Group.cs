using hehexd.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd.composite
{
    class Group : IComponent
    {
        public static string FigureType = "group";
        private List<IComponent> figures;
        
        public Group()
        {
            figures = new List<IComponent>();
        }

        public void remove(IComponent figure)
        {
            figures.Remove(figure);
        }

        public void add(IComponent figure)
        {
            figures.Add(figure);
        }

        public List<IComponent> returnFigures()
        {
            return figures;
        }

        public int getSize()
        {
            return figures.Count;
        }

        //public List<string> Serialize()
        //{
        //    return null;
        //}

        public void Drawshape()
        {
            foreach(IComponent figure in figures)
            {
                figure.Drawshape();
            }
        }

        public void Drag()
        {
            foreach(IComponent figure in figures)
            {
                figure.Drag();
            }
        }

        public Group findGroup(IComponent figure)
        {
            foreach (IComponent f in figures)
            {
                if (f.Equals(figure))
                    return this;
                if (f is Group)
                {
                    Group result = ((Group)f).findGroup(figure);
                    if (result != null) return result;
                }
            }
            return null;
        }
    }
}
