using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IHuman> humans = new List<IHuman>();
            
            int N = int.Parse(Console.ReadLine());
            for (int i = 0; i < N; i++)
            {
                string[] data = Console.ReadLine().Split();
                
                if (data.Length == 3)
                {
                    IHuman rebel = new Rebel(data[0], data[1], data[2]);
                    humans.Add(rebel);
                }
                else if (data.Length == 4)
                {
                    IHuman citizen = new Citizen(data[0], data[1], data[2], data[3]);
                    humans.Add(citizen);
                }
               
            }

            string inputNames = Console.ReadLine();
            while (inputNames != "End")
            {
                foreach (var citizen in humans)
                {
                    if (citizen.Name == inputNames)
                    {
                        citizen.BuyFood();
                    }
                }
                
                inputNames = Console.ReadLine();
            }

            Console.WriteLine(humans.Sum(x => x.Food));
        }
    }
}
