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
            Dictionary<Variable, Variable> data)
        {
            var after = before.Clone();

            foreach (var q in after.Quantifiers)
            {
                Replace(data, q.Variable);
            }
            foreach (var child in after.Term.Traverse())
            {
                if (child is Variable)
                {
                    var v = (Variable)child;
                    Replace(data, v);
                }
            }

            return after;
        }

        private static void Replace(
            Dictionary<Variable, Variable> data, Variable v)
        {
            foreach (var variable in data)
            {
                if (variable.Key.Equals(v))
                {
                    v.ChangeTo(variable.Value);
                }
            }
        }
    }
}
