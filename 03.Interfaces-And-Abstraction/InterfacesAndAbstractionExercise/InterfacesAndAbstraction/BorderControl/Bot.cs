using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Bot : IRobot
    {
        public Bot(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; set; }
        public string Id { get; set; }
    }
}
