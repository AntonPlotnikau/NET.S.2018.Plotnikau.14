using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection.Tests
{
    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return (x.X + y.Y) - (y.X + y.X);
        }
    }
}
