using Collection.Interfaces;
using System.Collections.Generic;

namespace Collection.Classes
{
    public class AddCollection : IAddCollection
    {
        List<string> addCollection = new List<string>();
        public int Add(string input)
        {
            addCollection.Add(input);
            return addCollection.Count - 1;
        }
    }
}
