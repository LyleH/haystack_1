﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlacks.BusinessRules
{
    internal sealed class Range
    {
        public Range(int start)
        {
            Start = start;
        }

        public Range(int start, int end)
        {
            Start = start;
            End = end;
        }

        public int Start { get; private set; }

        public int End { get; set; }
    }
}
