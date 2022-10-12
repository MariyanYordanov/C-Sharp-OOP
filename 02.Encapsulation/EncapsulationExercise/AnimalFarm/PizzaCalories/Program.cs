using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputPizza = Console.ReadLine().Split();
            string[] inputDough = Console.ReadLine().Split();

            string pizzaName = inputPizza[1];

            string flourType = inputDough[1];
            string bakingTechnique = inputDough[2];
            int weight = int.Parse(inputDough[3]);

            try
            {
                Dough dough = new Dough(flourType, bakingTechnique, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] toppingInfo = input.Split();

                    string toppingType = toppingInfo[1];
                    int grams = int.Parse(toppingInfo[2]);

                    Topping topping = new Topping(toppingType, grams);

                    pizza.AddTopping(topping);

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
