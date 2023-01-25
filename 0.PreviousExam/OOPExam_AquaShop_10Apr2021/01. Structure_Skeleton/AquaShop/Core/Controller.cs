using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorations;
        private readonly List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                decorations.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                decorations.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            return $"Successfully added { decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            bool isSuitable = false;
            IAquarium aquariumToAddFish = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                aquariumToAddFish.AddFish(new FreshwaterFish(fishName, fishSpecies, price));
                if (aquariumToAddFish.GetType().Name == "FreshwaterAquarium")
                {
                    isSuitable = true;
                }
            }
            else if (fishType == "SaltwaterFish")
            {
                aquariumToAddFish.AddFish(new SaltwaterFish(fishName, fishSpecies, price));
                if (aquariumToAddFish.GetType().Name == "SaltwaterAquarium")
                {
                    isSuitable = true;
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            if (isSuitable)
            {
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                return $"Water not suitable.";
            }
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquariumToFeedFish = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            var value = aquariumToFeedFish.Fish.Sum(x => x.Price) +
                aquariumToFeedFish.Decorations.Sum(x => x.Price);

            return $"The value of Aquarium {aquariumName} is {value:f2}.";
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquariumToFeedFish = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquariumToFeedFish.Feed();

            return $"Fish fed: {aquariumToFeedFish.Fish.Count}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration desiredDecoration = decorations.FindByType(decorationType);

            if (desiredDecoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            decorations.Remove(desiredDecoration);

            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);

            aquarium.AddDecoration(desiredDecoration);

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString();
        }
    }
}
