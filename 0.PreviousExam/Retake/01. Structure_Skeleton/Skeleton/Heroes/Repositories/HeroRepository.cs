using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> herous;

        public HeroRepository()
        {
            herous = new List<IHero>();
        }

        public IReadOnlyCollection<IHero> Models => herous;

        public void Add(IHero model)
            => herous.Add(model);

        public IHero FindByName(string name)
            => herous.FirstOrDefault(x => x.Name == name);

        public bool Remove(IHero model)
            => herous.Remove(model);
    }
}
