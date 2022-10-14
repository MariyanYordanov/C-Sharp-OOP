using System;
using Collection.Classes;
using Collection.Interfaces;

namespace Collection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int number = int.Parse(Console.ReadLine());

            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();

            foreach (var item in input)
            {
                int temp = addCollection.Add(item);
                Console.Write(temp + " ");
            }

            Console.WriteLine();
            foreach (var item in input)
            {
                int temp = addRemoveCollection.Add(item);
                Console.Write(temp + " ");
            }

            Console.WriteLine();
            foreach (var item in input)
            {
                int temp = myList.Add(item);
                Console.Write(temp + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < number; i++)
            {
                Console.Write(addRemoveCollection.Remove() + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < number; i++)
            {
                Console.Write(myList.Remove() + " ");
            }
        }
    }
}
