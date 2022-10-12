using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] inputPeople = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            string[] inputProducts = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Person> people = new Dictionary<string, Person>();

            Dictionary<string, Product> products = new Dictionary<string, Product>();

            try
            {
                for (int i = 0; i < inputPeople.Length; i+=2)
                {
                    string name = inputPeople[i];
                    decimal money = decimal.Parse(inputPeople[i + 1]);

                    Person person = new Person(name, money);

                    people.Add(name, person);
                }

                for (int i = 0; i < inputProducts.Length; i+=2)
                {
                    string name = inputProducts[i];
                    decimal cost = decimal.Parse(inputProducts[i + 1]);

                    Product product = new Product(name, cost);

                    products.Add(name, product);
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] commandInfo = command.Split();

                    string personName = commandInfo[0];
                    string productName = commandInfo[1];
                    
                    Person person = people[personName];
                    Product product = products[productName];

                    bool isAdded = person.AddProduct(product);

                    if (!isAdded)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }

                    command = Console.ReadLine();
                }

                foreach (var (name, person) in people)
                {
                    string productMessage = person.Products.Count > 0
                        ? string.Join(", ", person.Products.Select(x => x.Name))
                        : "Nothing bought";

                    Console.WriteLine($"{name} - {productMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
