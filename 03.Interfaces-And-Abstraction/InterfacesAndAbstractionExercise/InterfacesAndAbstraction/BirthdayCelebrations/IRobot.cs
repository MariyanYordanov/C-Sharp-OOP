using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IRobot : ICitizen
    {
        public string Id { get; set; }
    }
}
