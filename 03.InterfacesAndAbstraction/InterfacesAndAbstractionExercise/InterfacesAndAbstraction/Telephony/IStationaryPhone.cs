using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IStationaryPhone
    {
        string Number { get; set; }
        string Call(string number);
    }
}
