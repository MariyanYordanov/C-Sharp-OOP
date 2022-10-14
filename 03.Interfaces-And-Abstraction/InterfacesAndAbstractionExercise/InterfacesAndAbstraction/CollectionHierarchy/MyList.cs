using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : IMyList
    {
        List<string> myList = new List<string>();
        public int Used => myList.Count;

        public int Add(string input)
        {
            myList.Add(input);
            return myList.LastIndexOf();
        }

        public void Remove(string input)
        {
            myList.Remove(input);
        }
    }
}
