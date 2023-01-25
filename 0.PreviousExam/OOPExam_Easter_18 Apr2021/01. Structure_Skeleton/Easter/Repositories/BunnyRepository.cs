using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> bunies;

        public BunnyRepository()
        {
            this.bunies = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models => this.bunies;

        public void Add(IBunny model)
            => this.bunies.Add(model);

        public IBunny FindByName(string name)
            => this.bunies.FirstOrDefault(x => x.Name == name);

        public bool Remove(IBunny model)
            => this.bunies.Remove(model);
    }
}
