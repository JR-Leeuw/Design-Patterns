using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd.Commands
{
    public interface IRCommand : ICommand
    {
        void Unexecute(DrawingCanvas dc);
    }
}
