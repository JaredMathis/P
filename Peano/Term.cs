namespace Peano
{
    public abstract class Term
    {
        public abstract object Clone();

        public virtual IEnumerable<Term> Traverse()
        {
            yield return this;
        }
    }
}