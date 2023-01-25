using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            for (int i = 0; i < astronauts.Count; i++)
            {
                IAstronaut astronaut = astronauts.First();
                while (planet.Items.Count > 0 && astronaut.CanBreath)
                {
                    var item = planet.Items.FirstOrDefault();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    astronaut.Breath();
                    if (!astronaut.CanBreath)
                    {
                        astronauts.Remove(astronaut);
                    }
                }
            }
        }

    }
}
