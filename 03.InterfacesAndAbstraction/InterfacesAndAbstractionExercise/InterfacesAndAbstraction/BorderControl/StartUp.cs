using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<ICitizen> citizens = new List<ICitizen>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split();
                if (data.Length == 2)
                {
                    ICitizen robot = new Bot(data[0],data[1]);
                    citizens.Add(robot);
                }
                else if (data.Length == 3)
                {
                    ICitizen human = new Human(data[0], data[1], data[2]);
                    citizens.Add(human);
                }

                input = Console.ReadLine();
            }

            string fakeId = Console.ReadLine();
            foreach (var member in citizens)
            {
                if (member.Id.EndsWith(fakeId))
                {
                    Console.WriteLine(member.Id);
                }
            }
        }
    }
}
