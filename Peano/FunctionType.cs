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
        public FunctionType(string name, int childrenCount)
        {
            Name = name;
            ChildrenCount = childrenCount;
        }

        public string Name { get; set; }

        public int ChildrenCount { get; set; }

        public FunctionTerm Term(params Term[] arguments)
        {
            arguments.Length.Equals(ChildrenCount).Assert();

            return new FunctionTerm(this, arguments.ToList());
        }
    }
}
