using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Human : IHuman
    {
        public Human(string name, string age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; set; }
        public string Age { get; set; }
        public string Id { get; set; }
    }
}
