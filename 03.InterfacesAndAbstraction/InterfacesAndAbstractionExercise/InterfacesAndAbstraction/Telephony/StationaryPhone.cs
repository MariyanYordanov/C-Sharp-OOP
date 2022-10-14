using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IStationaryPhone
    {
        public string Number { get; set; }

        public string Call(string number)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Dialing... {number}");
            return stringBuilder.ToString().TrimEnd();
        }

    }
}
