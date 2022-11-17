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
            foreach (var t in after.Term.Traverse())
            {
                var twc = t as TermWithChildren;
                if (twc != null)
                {
                    var children = twc.Children;
                    foreach (var i in children.Indices())
                    {
                        Term childAtI = children.ElementAt(i);
                        if (childAtI.Equals(left))
                        {
                            if (found == position)
                            {
                                twc.Children = children.ReplaceAt(i, right).ToArray();
                                replaced = true;
                            }
                            found++;
                        }
                    }
                }
            }
            if (!replaced)
            {
                throw new Exception();
            }
            return after;
        }
    }
}
