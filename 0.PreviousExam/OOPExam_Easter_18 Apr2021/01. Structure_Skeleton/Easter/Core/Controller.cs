using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Easter.Models.Workshops.Contracts;
using Easter.Models.Workshops;

namespace Easter.Core.Contracts
{
    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunies;
        private readonly IRepository<IEgg> eggs;
        private readonly IWorkshop workshop;

        public Controller()
        {
            this.bunies = new BunnyRepository();
            this.eggs = new EggRepository();
            this.workshop = new Workshop();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException("Invalid bunny type.");
            }

            this.bunies.Add(bunny);

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(
                    "The bunny you want to add a dye to doesn't exist!");
            }

            IDye dye = new Dye(power);

            bunny.AddDye(dye);

            return $"Successfully added dye with power" +
                $" {power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);

            this.eggs.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            List<IBunny> bunniesToWork = this.bunies.Models
                .Where(x => x.Energy >= 50)
                .OrderByDescending(x => x.Energy)
                .ToList();

            if (bunniesToWork == null)
            {
                throw new InvalidOperationException("There is no bunny ready to start coloring!");
            }

            IEgg egg = eggs.FindByName(eggName);

            foreach (var bunn in bunniesToWork)
            {
                this.workshop.Color(egg, bunn);

                if (bunn.Energy == 0)
                {
                    this.bunies.Remove(bunn);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            return $"Egg {eggName} is {(egg.IsDone() ? "done" : "not done")}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{eggs.Models.Count(x => x.IsDone())} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var bunny in bunies.Models)
            {
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
