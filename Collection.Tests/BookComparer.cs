using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Tests
{
    public class BookComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return -x.CompareTo(y);
        }
    }
}
