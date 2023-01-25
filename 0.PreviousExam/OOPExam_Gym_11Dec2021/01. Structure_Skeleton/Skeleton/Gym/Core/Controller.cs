using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private readonly List<IGym> gyms;
        private readonly EquipmentRepository equipment;

        public Controller()
        {
            gyms = new List<IGym>();
            equipment = new EquipmentRepository();
        }

        public string AddAthlete(
            string gymName,
            string athleteType,
            string athleteName,
            string motivation,
            int numberOfMedals)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            if (athleteType == nameof(Boxer))
            {
                Boxer boxer = new Boxer(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name != nameof(BoxingGym))
                {
                    return $"The gym is not appropriate.";
                }

                gym.AddAthlete(boxer);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                Weightlifter weightlifter = new Weightlifter(athleteName, motivation, numberOfMedals);

                if (gym.GetType().Name != nameof(WeightliftingGym))
                {
                    return $"The gym is not appropriate.";
                }

                gym.AddAthlete(weightlifter);
            }
            else
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType == "Kettlebell")
            {
                equipment.Add(new Kettlebell());
            }
            else if (equipmentType == "BoxingGloves")
            {
                equipment.Add(new BoxingGloves());
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            return $"Successfully added {equipmentType}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType == "BoxingGym")
            {
                gyms.Add(new BoxingGym(gymName));
            }
            else if (gymType == "WeightliftingGym")
            {
                gyms.Add(new WeightliftingGym(gymName));
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            return $"Successfully added {gymType}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            double value = gym.EquipmentWeight;
            return $"The total weight of the equipment in the gym" +
                $" {gymName} is {value:f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment eq = equipment.FindByType(equipmentType);

            if (eq == null)
            {
                throw new InvalidOperationException(
                    $"There isn’t equipment of type {equipmentType}.");
            }

            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);

            gym.AddEquipment(eq);
            equipment.Remove(eq);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            foreach (var gym in gyms)
            {
                result.AppendLine(gym.GymInfo());
            }

            return result.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(x => x.Name == gymName);
            gym.Exercise();
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
