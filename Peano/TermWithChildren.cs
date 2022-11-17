using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peano
{
    public abstract class TermWithChildren : Term
    {
        public TermWithChildren(IEnumerable<Term> children)
        {
            Children = children;
        }

        public IEnumerable<Term> Children { get; set; }

        public override IEnumerable<Term> Traverse()
        {
            foreach (var r in base.Traverse())
            {
                yield return r;
            }
            foreach (var c in Children)
            {
                foreach (var r in c.Traverse())
                {
                    yield return r;
                }
            }

        }
    }
}
