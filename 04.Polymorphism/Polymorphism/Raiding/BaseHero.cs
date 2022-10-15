namespace Raiding
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; private set; }
        public int Power { get;}

        public virtual string CastAbility()
        {
            return $"{GetType().Name} - {Name} healed for {Power}";
        }

    }
}
