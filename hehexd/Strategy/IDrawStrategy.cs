using hehexd.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace hehexd.Strategy
{
    public interface IDrawStrategy
    {
        UIElement doOperation();
    }
}
