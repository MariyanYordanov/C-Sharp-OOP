using Collection.Interfaces;
using System.Collections.Generic;

namespace Collection.Classes
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        List<string> addRemoveCollection = new List<string>();
        public int Add(string input)
        {
            addRemoveCollection.Insert(0,input);
            return 0;
        }

        public string Remove()
        {
            string result = addRemoveCollection[^1]; 
            addRemoveCollection.RemoveAt(addRemoveCollection.Count - 1);
            return result;
        }
    }
}
