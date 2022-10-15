using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<IHero> heroes = new List<IHero>();
            while (heroes.Count < N)
            {
                try
                {
                    heroes.Add(HeroFactory.CreateHero());
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            string input = Console.ReadLine();
            while (true)
            {
                bool isDigit = false;
                for (int i = 0; i < input.Length; i++)
                {
                    if (!char.IsDigit(input[i]))
                    {
                        isDigit = false;
                        break;
                    }
                    else
                    {
                        isDigit = true;
                    }
                }

                if (isDigit == true)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            int bossPower = int.Parse(input);
            int heroesPower = heroes.Sum(x => x.Power);
            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));
            Console.WriteLine(heroesPower >= bossPower ? "Victory!" : "Defeat...");

        }
    }
}
