using Collection.Interfaces;
using System.Collections.Generic;

namespace Collection.Classes
{
    public class MyList : IMyList
    {
        List<string> myList = new List<string>();

        public int MyProperty { get; set; }

        public int Used => myList.Count;

        public int Add(string input)
        {
            myList.Insert(0,input);
            return 0;
        }

        public string Remove()
        {
            string result = myList[0];
            myList.RemoveAt(0);
            return result;
        }
    }
}
