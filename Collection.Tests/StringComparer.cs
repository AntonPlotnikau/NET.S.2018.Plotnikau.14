using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Tests
{
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return -x.CompareTo(y);
        }
    }
}
