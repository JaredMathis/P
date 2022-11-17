using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public class FunctionType
    {
        public FunctionType(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public FunctionTerm Term(params Term[] arguments)
        {
            return new FunctionTerm(this, arguments.ToList());
        }
    }
}
