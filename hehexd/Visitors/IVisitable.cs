﻿using hehexd.composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hehexd.Visitors
{
    public interface IVisitable
    {
        void accept(IVisitor visitor);
    }
}
