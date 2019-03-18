﻿using hehexd.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd.Commands
{
    public class DrawCommand : IRCommand
    {

        private AbstractShape shape;


        public DrawCommand(AbstractShape shape)
        {
            this.shape = shape;
        }

        public void Execute(DrawingCanvas dc)
        {
            //do draw shit (gooi in lijs en redraw canvas)
            dc.GetCanvas().Children.Add(shape.GetObject());

        }

        public void Unexecute(DrawingCanvas dc)
        {
            //dc.GetCanvas().Children.Remove(shape.GetObject());
        }

        public void Delete(DrawingCanvas dc)
        {
            dc.GetCanvas().Children.RemoveAt(dc.GetCanvas().Children.Count - 1);
        }
    }
}
