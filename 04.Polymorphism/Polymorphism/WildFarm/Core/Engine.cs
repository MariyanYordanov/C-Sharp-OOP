namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;
    using Factories;
    using Contracts;

    public class Engine
    {
        private readonly ICollection<IAnimal> animals;

        public Engine()
        {
            animals = new List<IAnimal>();
        }

        public void Run()
        {
            while (true)
            {
                string[] animalInfo = Console.ReadLine().Split();

                if (animalInfo[0] == "End")  break;
                
                string[] foodInfo = Console.ReadLine().Split();
                try
                {
                    IAnimal animal = Factories.AnimalFactory.CreateAnimal(animalInfo);

                    Console.WriteLine(animal.Sound);

                    animals.Add(animal);

                    IFood food = Factories.FoodFactory.CreateFood(foodInfo);

                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
