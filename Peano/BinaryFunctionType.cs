using Peano.Extensions.Msft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public class BinaryFunctionType : FunctionType
    {
        public BinaryFunctionType(string name)
            :base(name, 2)
        {
        }
    }
}
