using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<Person> persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                string[] commands = Console.ReadLine().Split();
                Person person = new Person(commands[0], 
                                           commands[1], 
                                 int.Parse(commands[2]), 
                             decimal.Parse(commands[3]));
                persons.Add(person);
            }
            
            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reseve team has {team.ReseveTeam.Count} players.");
        }
    }
}
