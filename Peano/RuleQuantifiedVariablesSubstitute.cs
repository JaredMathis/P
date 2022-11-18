using Peano.Extensions.Msft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public class RuleQuantifiedVariablesSubstitute
    {
        public QuantifiedTerm Apply(
            QuantifiedTerm before,
            Dictionary<Variable, Term> data,
            params Quantifier[] newQuantifiers)
        {
            var after = before.Clone();

            after.Quantifiers = newQuantifiers.ToList();

            after.Term.TraverseWithChildren((twc, childAtI, i) =>
            {
                var v = childAtI as Variable;
                if (v != null)
                {
                    foreach (var variable in data)
                    {
                        if (variable.Key.Equals(v))
                        {
                            twc.Children = twc.Children.ReplaceAt(i, variable.Value).ToArray();
                        }
                    }
                }
            });

            return after;
        }
    }
}
