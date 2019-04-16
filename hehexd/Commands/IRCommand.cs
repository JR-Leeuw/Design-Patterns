using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd.Commands
{
    public interface IRCommand : ICommand
    {
        void ReExecute(DrawingCanvas dc);
        void Unexecute(DrawingCanvas dc);
    }
}
