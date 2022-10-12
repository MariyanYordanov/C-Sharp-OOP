using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reseveTeam;

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reseveTeam = new List<Person>();
        }

        public IReadOnlyCollection<Person> FirstTeam => this.firstTeam.AsReadOnly();
        public IReadOnlyCollection<Person> ReseveTeam => this.reseveTeam.AsReadOnly();

        public string Name { get => this.name; set => this.name = value; }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                this.firstTeam.Add(player);
            }
            else
            {
                this.reseveTeam.Add(player);
            }
        }

    }
}
