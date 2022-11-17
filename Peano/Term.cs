namespace Peano
{
    public abstract class Term
    {
        public abstract object Clone();

        public virtual IEnumerable<Term> Traverse()
        {
            yield return this;
        }
        public override bool Equals(object? obj)
        {
            return ToString().Equals(obj.ToString());
        }
    }
}