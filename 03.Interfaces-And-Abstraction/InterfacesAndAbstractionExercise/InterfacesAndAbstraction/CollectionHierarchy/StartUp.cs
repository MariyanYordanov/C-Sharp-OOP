using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            for (int i = 0; i < input.Length; i++)
            {
                IMyList myList = new MyList();
                IAddCollection addCollection = new AddCollection();
                IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
                int index = myList.Add(input[i]);
                addCollection.Add(input[i]);
                addRemoveCollection.Add(input[i]);
            }

        }
    }
}
