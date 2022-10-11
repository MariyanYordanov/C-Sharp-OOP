using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animals> animals = new List<Animals>();
            
            while (true)
            {
                string animalType = Console.ReadLine();
                if (animalType == "Beast!")
                {
                    break;
                }
                
                string[] animalData = System.Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = animalData[0];
                int  age = int.Parse(animalData[1]);
                string gender = animalData[2];
                
                if (animalType == "Cat")
                {
                    Animals animal = new Cat(name, age, gender);
                    animals.Add(animal);
                }
                else if (animalType == "Kitten")
                {
                    Animals animal = new Kitten(name, age);
                    animals.Add(animal);
                }
                else if (animalType == "Tomcat")
                {
                    Animals animal = new Tomcat(name, age);
                    animals.Add(animal);
                }
                else if (animalType == "Dog")
                {
                    Animals animal = new Dog(name, age, gender);
                    animals.Add(animal);
                }
                else if (animalType == "Frog")
                {
                    Animals animal = new Frog(name, age, gender);
                    animals.Add(animal);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
