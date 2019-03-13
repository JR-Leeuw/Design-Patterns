using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace hehexd.Shapes
{
    public abstract class AbstractShape
    {
        protected Point start;
        protected Point end;

        public abstract void Draw(Canvas canvas);
        public abstract Shape GetObject();
    }
}
