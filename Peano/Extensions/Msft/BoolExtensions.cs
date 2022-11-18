using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano.Extensions.Msft
{
    public static class BoolExtensions
    {
        public static void Assert(this bool b)
        {
            if (!b)
            {
                throw new Exception();
            }
        }
    }
}
