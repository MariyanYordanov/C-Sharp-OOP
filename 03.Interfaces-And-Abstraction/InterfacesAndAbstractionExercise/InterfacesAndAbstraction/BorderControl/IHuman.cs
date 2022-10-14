using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IHuman : ICitizen
    {
        public string Age { get; set; }
    }
}
