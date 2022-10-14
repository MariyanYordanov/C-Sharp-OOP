using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : ICitizen, IBuyer
    {
        private int food;
        public Citizen(string name, string age, string id, string birthdate)
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
        public int Food { get => food; set => food = 0; }

        public void BuyFood()
        {
            this.food += 10;
        }
    }
}
