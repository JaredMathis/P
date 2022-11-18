using Peano.Extensions.Msft;
using System.Diagnostics.Metrics;
using System;

namespace Peano
{
    public abstract class Term
    {
        public abstract object Clone();

        public virtual IEnumerable<Term> Traverse()
        {
            yield return this;
        }
        public void TraverseWithChildren(Action<TermWithChildren, Term, int> a)
        {
            foreach (var t in this.Traverse())
            {
                var twc = t as TermWithChildren;
                if (twc != null)
                {
                    var children = twc.Children;
                    foreach (var i in children.Indices())
                    {
                        Term childAtI = children.ElementAt(i);
                        a(twc, childAtI, i);
                    }
                }
            }
        }

        public override bool Equals(object? obj)
        {
            return ToString().Equals(obj.ToString());
        }
    }
}