using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        List<string> addRemoveCollection = new List<string>();
        public int Add(string input)
        {
            addRemoveCollection.Add(input);
            return addRemoveCollection.Last
        }

        public string Remove(string input)
        {
            addRemoveCollection.Remove(input);
        }
    }
}
