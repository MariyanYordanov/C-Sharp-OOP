using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.name = name;
            players = new List<Player>();
        }

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

        public int Rating
            => players.Any()
            ? (int)Math.Round(this.players.Average(x => x.Stats))
            : 0;

        public void AddPlayer(Player player) => players.Add(player);
        
        public bool RevomePlayer(string name)
        {
            Player player = players.FirstOrDefault(x => x.Name == name);
            return players.Remove(player);
        }
    }
}
