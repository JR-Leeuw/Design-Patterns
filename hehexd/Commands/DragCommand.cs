using hehexd.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace hehexd.Commands
{
    public class DragCommand : ICommand
    {
        protected Point start;
        protected Point end;
        private AbstractFigure figure;

        public DragCommand(AbstractFigure figure)
        {
            this.figure= figure;
        }

        public void Delete(DrawingCanvas dc)
        {
            
        }

        public void Execute(DrawingCanvas dc)
        {
            figure.Drag();
        }
    }
}
