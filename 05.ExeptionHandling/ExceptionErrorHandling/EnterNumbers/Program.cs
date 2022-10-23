using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            while (numbers.Count < 10)
            {
                string input = Console.ReadLine();
                try
                {
                    if (int.TryParse(input, out int result))
                    {
                        if (result < 2 || result > 99)
                        {
                            throw new ArgumentException(
                                $"Your number is not in range {numbers.Count + 1} - 100!");
                        }
                        
                        numbers.Add(result);
                    }
                    else
                    {
                        throw new FormatException("Invalid Number!");
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.Write(string.Join(", ", numbers));
        }

    }
}
