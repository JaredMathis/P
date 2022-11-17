using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public class Quantifier
    {
        public Quantifier(QuantifierType type, Variable variable)
        {
            Type = type;
            Variable = variable;
        }
    
        public QuantifierType Type { get; set; }
        public Variable Variable { get; set; }

        public override string ToString()
        {
            return $@"{Type}{Variable}";
        }

        internal object Clone()
        {
            return new Quantifier(Type, Variable.Clone());
        }
    }
}
