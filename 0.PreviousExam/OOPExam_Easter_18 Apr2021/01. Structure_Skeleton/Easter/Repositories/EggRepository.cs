using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg>eggs;

        public EggRepository()
        {
            eggs = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models => eggs;

        public void Add(IEgg model)
            => eggs.Add(model);

        public IEgg FindByName(string name)
            => eggs.FirstOrDefault(x => x.Name == name);

        public bool Remove(IEgg model)
            => eggs.Remove(model);
    }
}
