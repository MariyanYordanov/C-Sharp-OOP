using Gym.Models.Athletes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int stamina;
        private int numberOfMedals;

        public Athlete(
            string fullName,
            string motivation,
            int stamina,
            int numberOfMedals)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.Stamina = stamina;
            this.NumberOfMedals = numberOfMedals;
        }

        public string FullName
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(
                        $"Athlete name cannot be null or empty.");
                }

                this.fullName = value;
            }
        }

        public string Motivation
        {
            get => this.motivation;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(
                        $"The motivation cannot be null or empty.");
                }

                this.motivation = value;
            }
        }

        public int Stamina
        {
            get => this.stamina;
            protected set
            {
                if (value >= 100)
                {
                    this.Stamina = 100;
                    throw new ArgumentException($"Stamina cannot exceed 100 points.");
                }

                this.stamina = value;
            }
        }

        public int NumberOfMedals
        {
            get => this.numberOfMedals;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        $"Athlete's number of medals cannot be below 0.");
                }

                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
