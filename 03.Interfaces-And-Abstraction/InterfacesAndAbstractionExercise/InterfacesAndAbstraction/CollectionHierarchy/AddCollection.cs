using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        List<string> addCollect = new List<string>();
        public int Add(string input)
        {
            addCollect.Add(input);
        }
    }
}
