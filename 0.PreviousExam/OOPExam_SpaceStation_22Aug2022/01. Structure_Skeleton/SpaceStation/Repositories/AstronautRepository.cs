﻿using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => astronauts.AsReadOnly();

        public void Add(IAstronaut model)
            => astronauts.Add(model);

        public IAstronaut FindByName(string name)
            => astronauts.FirstOrDefault(astronaut => astronaut.Name == name);

        public bool Remove(IAstronaut model)
            => astronauts.Remove(model);
    }
}
