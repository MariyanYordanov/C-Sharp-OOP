using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ISmartphone : IStationaryPhone
    {
        string URL { get; set; }
        string Browsing(string url);
    }
}
