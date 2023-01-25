using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private readonly ICollection<IEquipment> equipments;
        private readonly ICollection<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            equipments = new List<IEquipment>();
            athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Gym name cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight => Equipment.Select(x => x.Weight).Sum();

        public ICollection<IEquipment> Equipment => this.equipments;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count >= this.Capacity)
            {
                throw new InvalidOperationException($"Not enough space in the gym.");
            }

            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }

        }

        public string GymInfo()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.Name} is a {this.GetType().Name}:");

            string athletes;
            if (Athletes.Count > 0)
            {
                athletes = string.Join(", ", Athletes.Select(x => x.FullName));
            }
            else
            {
                athletes = "No athletes";
            }

            stringBuilder.AppendLine($"Athletes: {athletes}");

            stringBuilder.AppendLine($"Equipment total count:" +
                $" {this.Equipment.Count}");

            stringBuilder.AppendLine($"Equipment total weight:" +
                $" {this.EquipmentWeight:f2} grams");

            return stringBuilder.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
