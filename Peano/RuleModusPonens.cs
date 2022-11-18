using Peano.Extensions.Msft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public class RuleModusPonens
    {
        public QuantifiedTerm Apply(QuantifiedTerm pImpliesQ, QuantifiedTerm p)
        {
            var center = pImpliesQ.Term as FunctionTerm;
            var centerChildren = center.Children;
            var left = centerChildren.First();
            var right = centerChildren.Second();

            left.Equals(p.Term).Assert();

            var result = (QuantifiedTerm)p.Clone();
            result.Term = (Term)right.Clone();
            return result;
        }
    }
}
