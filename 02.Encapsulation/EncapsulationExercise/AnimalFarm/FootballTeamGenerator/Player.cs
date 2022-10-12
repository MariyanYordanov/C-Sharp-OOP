using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            CheckSkills("Endurance", endurance);
            CheckSkills("Sprint", sprint);
            CheckSkills("Dribble", dribble);
            CheckSkills("Passing", passing);
            CheckSkills("Shooting", shooting);
            this.endurance = endurance;
            this.sprint = sprint;
            this.dribble = dribble;
            this.passing = passing;
            this.shooting = shooting;
        }

        public double Stats => (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5.0;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }

        private void CheckSkills(string name, int skill)
        {
            if (skill < 0 || skill > 100)
            {
                throw new ArgumentException($"{name} should be between 0 and 100.");
            }
        }
    }
}
