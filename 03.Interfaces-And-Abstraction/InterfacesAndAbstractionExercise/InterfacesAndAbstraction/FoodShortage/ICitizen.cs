using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface ICitizen : IHuman, IBuyer
    {
        public string Id { get; set; }
        public string Birthdate { get; set; }
    }
}
