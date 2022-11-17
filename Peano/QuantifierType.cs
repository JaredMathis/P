namespace Peano
{
    public class QuantifierType
    {
        public string Symbol { get; private set; }
        public string Name { get; private set; }

        public QuantifierType(string symbol, string name)
        {
            this.Symbol = symbol;
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name + " ";
        }

        public static QuantifierType All { get; set; } = new QuantifierType("∀", "all");
        public static QuantifierType Exists { get; set; } = new QuantifierType("∃", "exists");
    }
}