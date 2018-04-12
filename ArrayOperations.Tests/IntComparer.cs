using System;
using System.Collections.Generic;

namespace ArrayOperations.Tests
{
    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x - y;
        }
    }
}
