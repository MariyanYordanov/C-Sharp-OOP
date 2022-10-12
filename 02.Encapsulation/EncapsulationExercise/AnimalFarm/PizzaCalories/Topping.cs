using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        private string toppingTypes;
        private int weight;

        public Topping(string toppingTypes, int weight)
        {
            this.ToppingTypes = toppingTypes;
            this.Weight = weight;
        }

        public string ToppingTypes
        {
            get => toppingTypes;
            private set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                toppingTypes = value;
            }
        }
        public int Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingTypes} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }
       
        
        public double Calories => 2 * this.Weight * modifiers[ToppingTypes.ToLower()];
    }
}
