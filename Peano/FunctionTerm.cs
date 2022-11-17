using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public class FunctionTerm : TermWithChildren
    {
        public FunctionTerm(FunctionType type, IEnumerable<Term> arguments) : base(arguments)
        {
            Type = type;
        }

        public FunctionType Type { get; }
        public override string ToString()
        {
            return $@"{Type.Name}({Delimeted(",", Children)})";
        }

        public static string Delimeted(
            string delimeter, IEnumerable<object> arguments)
        {
            return string.Join(
                delimeter, 
                arguments.Select(a => a.ToString()));
        }

        public override object Clone()
        {
            return new FunctionTerm(
                Type,
                Children.Select(a => (Term)a.Clone()).ToArray());
        }
    }
}
