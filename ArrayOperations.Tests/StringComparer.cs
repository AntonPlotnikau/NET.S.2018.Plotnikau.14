using System;
using System.Collections.Generic;

namespace ArrayOperations.Tests
{
    class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return String.Compare(x, y);
        }
    }
}
