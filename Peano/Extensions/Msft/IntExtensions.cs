using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano.Extensions.Msft
{
    public static class IntExtensions
    {
        public static IEnumerable<int> ToRange(this int i)
        {
            return Enumerable.Range(0, i);
        }
    }
}
