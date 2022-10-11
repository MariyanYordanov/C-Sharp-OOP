using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        Random rnd = new Random();
        public string RandomString()
        {
            if (Count == 0)
            {
                return null;
            }
            int ind = rnd.Next(0,Count);
            string el = this[ind];
            RemoveAt(ind);
            return el;
        }
    }
}
