using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> reces;

        public RaceRepository()
        {
            this.reces = new List<IRace>();
        }

        public void Add(IRace model)
            => this.reces.Add(model);

        public IReadOnlyCollection<IRace> GetAll()
            => this.reces.ToArray();

        public IRace GetByName(string name)
            => this.reces.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRace model)
            => this.reces.Remove(model);
    }
}
