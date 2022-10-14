using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<INoneBots> citizens = new List<INoneBots>();
            List<IRobot> robots = new List<IRobot>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split();
                string type = data[0];
                if (type == "Robot")
                {
                    IRobot robot = new Bot(data[1], data[2]);
                    robots.Add(robot);
                }
                else if (type == "Citizen")
                {
                    INoneBots human = new Human(data[1], data[2], data[3], data[4]);
                    citizens.Add(human);
                }
                else if (type == "Pet")
                {
                    INoneBots pet = new Pet(data[1], data[2]);
                    citizens.Add(pet);
                }
                input = Console.ReadLine();
            }

            string year = Console.ReadLine();
            foreach (var member in citizens)
            {
                if (member.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(member.Birthdate);
                }
            }
        }
    }
}
