namespace Peano
{
    public class Variable : Term
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return $@"{this.Name}";
        }

        internal void ChangeTo(Variable value)
        {
            this.Name = value.Name;
        }

        public override Variable Clone()
        {
            return new Variable()
            {
                Name = this.Name,
            };
        }
    }
}