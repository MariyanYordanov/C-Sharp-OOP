using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // Peter=11;George=4
            // Bread=10;Milk=2;
            string[] peopleAndMoneyInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] productsAndCostsInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries).Where(x => !string.IsNullOrEmpty(x)).ToArray();
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            foreach (var personWithMoney in peopleAndMoneyInput)
            {
                string[] splittedPersonWithMoney = personWithMoney.Split('=');
                string personsName = splittedPersonWithMoney[0];
                double personsMoney = double.Parse(splittedPersonWithMoney[1]);
                Person currentPerson = null;
                
                try
                {
                    currentPerson = new Person(personsName, personsMoney);
                    people.Add(currentPerson);
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }
            }
            foreach (var productWithPrice in productsAndCostsInput)
            {
                string[] splittedProductWithPrice = productWithPrice.Split('=');
                string productsName = splittedProductWithPrice[0];
                double productPrice = double.Parse(splittedProductWithPrice[1]);
                Product currentProduct = null;
                try
                {
                    currentProduct = new Product(productsName, productPrice);
                    products.Add(currentProduct);
                }
                catch (Exception ae)
                {

                    Console.WriteLine(ae.Message);
                    return;
                }

            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personsName = tokens[0];
                string productsName = tokens[1];
                if (people.Any(x => x.Name == personsName) && products.Any(x => x.Name == productsName))
                {
                    Person personNeeded = people.Find(x => x.Name == personsName);
                    Product productNeeded = products.Find(x => x.Name == productsName);

                    if (productNeeded.Cost <= personNeeded.Money)
                    {
                        try
                        {
                            personNeeded.Money -= productNeeded.Cost;
                            personNeeded.Products.Add(productNeeded);
                            Console.WriteLine($"{personsName} bought {productsName}");
                        }
                        catch (Exception ae)
                        {

                            Console.WriteLine($"{personsName} can't afford {productNeeded}");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{personsName} can't afford {productNeeded}");
                    }
                }
                command = Console.ReadLine();
            }

            foreach (var person in people)
            {
                    Console.WriteLine($"{person}");
            }
            ;
        }
    }
}
