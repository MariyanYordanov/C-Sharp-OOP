namespace SpaceStation.Models.Astronauts.Contracts
{
    using Bags;
    using Bags.Contracts;
    using System.Collections.Generic;

    public interface IAstronaut
    {
        string Name { get; }

        double Oxygen { get; }

        bool CanBreath { get; }

        IBag Bag { get; }

        void Breath();
    }
}