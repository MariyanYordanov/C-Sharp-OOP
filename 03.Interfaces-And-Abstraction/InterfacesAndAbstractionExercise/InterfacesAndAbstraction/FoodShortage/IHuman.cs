using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IHuman : IBuyer
    {
        public string Name { get; set; }
        public string Age { get; set; }
        
    }
}
