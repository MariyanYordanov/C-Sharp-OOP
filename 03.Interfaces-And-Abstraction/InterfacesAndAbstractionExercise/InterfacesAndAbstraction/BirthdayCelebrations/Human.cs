using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Human : IHuman, INoneBots
    {
        public Human(string name, string age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; set; }
        public string Age { get; set; }
        public string Id { get; set; }
        public string Birthdate { get; set; }
    }
}
