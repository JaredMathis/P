using Peano.Extensions.Msft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public class FunctionType
    {
        public FunctionType(string name, int argumentCount)
        {
            Name = name;
            _argumentCount = argumentCount;
        }

        public string Name { get; set; }

        private int _argumentCount;

        public FunctionTerm Term(params Term[] arguments)
        {
            arguments.Length.Equals(_argumentCount).Assert();

            return new FunctionTerm(this, arguments.ToList());
        }
    }
}
