using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    interface IRebel : IHuman, IBuyer
    {
        string Group { get; set; }
    }
}
