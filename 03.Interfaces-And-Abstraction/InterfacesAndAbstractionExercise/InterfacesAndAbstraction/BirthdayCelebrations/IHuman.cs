using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IHuman : ICitizen, INoneBots
    {
        public string Age { get; set; }
        public string Id { get; set; }
    }
}
