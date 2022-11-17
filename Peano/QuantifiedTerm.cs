using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public class QuantifiedTerm
    {
        public QuantifiedTerm(Term term, params Quantifier[] quantifiers)
        {
            Quantifiers = quantifiers.ToList();
            Term = term;
        }
    
        public List<Quantifier> Quantifiers { get; set; }
        public Term Term { get; set; }

        public override string ToString()
        {
            return $@"{FunctionTerm.Delimeted(" ", Quantifiers)} {Term}";
        }

        internal QuantifiedTerm Clone()
        {
            var result = new QuantifiedTerm((Term)this.Term.Clone(), this.Quantifiers.Select(a => (Quantifier)a.Clone()).ToArray());
            return result;
        }
    }
}
