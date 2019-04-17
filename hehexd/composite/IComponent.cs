using hehexd.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hehexd.composite
{
    public interface IComponent
    {
        void accept(IVisitor visitor);
        UIElement GetChild();
    }
}
