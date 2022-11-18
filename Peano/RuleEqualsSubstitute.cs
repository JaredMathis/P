using Peano.Extensions.Msft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public class RuleEqualsSubstitute
    {
        public QuantifiedTerm Apply(QuantifiedTerm before, QuantifiedTerm equalsRule, int position)
        {
            var center = equalsRule.Term as FunctionTerm;
            var centerChildren = center.Children;
            var left = centerChildren.First();
            var right = centerChildren.Second();


            var found = 0;
            var replaced = false;

            var after = before.Clone();
            after.Term.TraverseWithChildren((twc, childAtI, i) =>
            {
                if (childAtI.Equals(left))
                {
                    if (found == position)
                    {
                        twc.Children = twc.Children.ReplaceAt(i, right).ToArray();
                        replaced = true;
                    }
                    found++;
                }
            });
            replaced.Assert();

            return after;
        }
    }
}
