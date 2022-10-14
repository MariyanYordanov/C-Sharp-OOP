using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface INoneBots : ICitizen
    {
        public string Birthdate { get; set; }
    }
}
