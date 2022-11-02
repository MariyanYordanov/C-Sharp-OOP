using System;
using System.Collections.Generic;
using P03.Detail_Printer;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IEmployee employee = new Employee("Ivan");

            List<string> documents = new List<string>() { "23, ", "E gati" };

            IEmployee manager = new Manager("Ivanov", documents);

            List<IEmployee> empl = new List<IEmployee>();

            empl.Add(employee);
            empl.Add(manager);

            DetailsPrinter details = new DetailsPrinter(empl);

            Console.WriteLine(details.Print(manager)); 
        }
    }
}
