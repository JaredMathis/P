using Peano.Extensions.Msft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public class UnaryFunctionType : FunctionType
    {
        public UnaryFunctionType(string name)
            :base(name, 1)
        {
        }
    }
}
