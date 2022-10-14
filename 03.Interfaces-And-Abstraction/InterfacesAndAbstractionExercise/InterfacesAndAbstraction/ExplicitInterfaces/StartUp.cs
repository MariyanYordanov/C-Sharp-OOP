using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] data = input.Split();
                IPerson person = new Citizen(data[0], data[1], int.Parse(data[2]));
                Console.WriteLine(person.GetName());
                IResident resident = new Citizen(data[0], data[1], int.Parse(data[2]));
                Console.WriteLine(resident.GetName());

                input = Console.ReadLine();
            }
        }
    }
}
