using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly AstronautRepository astronauts;
        private readonly PlanetRepository planets;
        private readonly IMission mission;
        private int counterExplorer;

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
            mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronautToUse;
            if (type == "Biologist")
            {
                astronautToUse = new Biologist(astronautName);
            }
            else if (type == "Geodesist")
            {
                astronautToUse = new Geodesist(astronautName);
            }
            else if (type == "Meteorologist")
            {
                astronautToUse = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException("Astronaut type doesn't exists!");
            }

            astronauts.Add(astronautToUse);

            return $"Successfully added {astronautToUse.GetType().Name}: {astronautName}!";
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planetToUse = new Planet(planetName);
            foreach (var item in items)
            {
                planetToUse.Items.Add(item);
            }

            planets.Add(planetToUse);

            return $"Successfully added Planet: {planetName}!";
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planetToExplore = planets.FindByName(planetName);

            List<IAstronaut> astronautsToUse = 
            astronauts.Models.Where(a => a.Oxygen > 60).ToList();
            
            int missionStartAstronauts = astronautsToUse.Count;
            if (astronautsToUse.Count == 0)
            {
                throw new InvalidOperationException(
                    "You need at least one astronaut to explore the planet");
            }

            mission.Explore(planetToExplore, astronautsToUse);
            counterExplorer++;
            int deadAstronauts = missionStartAstronauts - astronautsToUse.Count;

            return $"Planet: {planetName} was explored!" +
                $" Exploration finished with {deadAstronauts} dead astronauts!";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{counterExplorer} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.AppendLine($"Bag items: none");
                }
                else
                {
                    sb.AppendLine($"Bag items: {string.Join(", ", astronaut.Bag.Items)}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronautToUse = astronauts.FindByName(astronautName);

            if (astronautToUse == null)
            {
                throw new InvalidOperationException($"Astronaut {astronautName} doesn't exists!");
            }

            astronauts.Remove(astronautToUse);

            return $"Astronaut {astronautToUse.Name} was retired!";
        }
    }
}
