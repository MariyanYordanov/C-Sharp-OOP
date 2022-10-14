using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ISmartphone
    {
        public string Number { get; set; }
        public string URL { get; set; }

        public string Browsing(string url)
        {
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Calling... {number}");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
