using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Tests
{
    public class IntComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }
}
