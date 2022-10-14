using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : IRebel, IBuyer
    {
        private int food;

        public Rebel(string name, string age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public string Name { get; set; }
        public string Age { get; set; }
        public string Group { get; set; }
        public int Food { get => food; set => food = 0; }

        public void BuyFood()
        {
            this.food += 5;
        }
    }
}
