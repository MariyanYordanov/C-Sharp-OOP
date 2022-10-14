using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] inputURL = Console.ReadLine().Split();
            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i];
                bool isDigit = true;
                for (int c = 0; c < number.Length; c++)
                {
                    if (!Char.IsDigit(number[c]))
                    {
                        Console.WriteLine("Invalid number!");
                        isDigit = false;
                        break;
                    }

                }

                if (!isDigit)
                {
                    continue;
                }

                if (number.Length == 10)
                {
                    ISmartphone smartphone = new Smartphone();
                    Console.WriteLine(smartphone.Call(number));
                }
                else if (number.Length == 7)
                {
                    IStationaryPhone stationary = new StationaryPhone();
                    Console.WriteLine(stationary.Call(number));
                }
            }

            for (int i = 0; i < inputURL.Length; i++)
            {
                string url = inputURL[i];
                bool isDigit = true;
                for (int j = 0; j < url.Length; j++)
                {
                    if (Char.IsDigit(url[j]))
                    {
                        Console.WriteLine("Invalid URL!");
                        isDigit = false;
                        break;
                    }
                }

                if (!isDigit)
                {
                    continue;
                }

                ISmartphone smartphone = new Smartphone();
                Console.WriteLine(smartphone.Browsing(url));
            }
        }
    }
}
