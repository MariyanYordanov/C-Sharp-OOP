using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> allToppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            allToppings = new List<Topping>();
        }


        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentNullException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }
        public Dough Dough { get; private set; }

        public double TotalCalories => this.Dough.Calories + allToppings.Sum(x => x.Calories);
        public void AddTopping(Topping topping)
        {
            if (allToppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            allToppings.Add(topping);
        }

    }
}
