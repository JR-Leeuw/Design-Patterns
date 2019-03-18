﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hehexd.Commands;

namespace hehexd.Tools
{
    public class RectangleTool : AbstractTool
    {
        public override ICommand getCommand(Point end, bool temporary)
        {
             if (temporary)
            {
                return new TempDrawCommand(new RectangleShape(this.start, end, child));
            }
            else
            {
                return new DrawCommand(new RectangleShape(this.start, end, child));
            }
        }

        public override bool NeedsShape()
        {
            return true;
        }
    }
}
