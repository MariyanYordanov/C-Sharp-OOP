﻿using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }

        public void Add(ICar model)
            => this.cars.Add(model);

        public IReadOnlyCollection<ICar> GetAll()
            => this.cars.ToArray();

        public ICar GetByName(string name)
            => this.cars.FirstOrDefault(x => x.Model == name);

        public bool Remove(ICar model)
            => this.cars.Remove(model);
    }
}
