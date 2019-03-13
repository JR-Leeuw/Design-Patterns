using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd
{
    class RectangleCommand : ICommand
    {
        private DrawRectangle drawrectangle;

        public RectangleCommand(DrawRectangle drawrectangle)
        {
            this.drawrectangle = drawrectangle;
        }

        public void Execute()
        {
            drawrectangle.Draw();
        }
    }
}
