using System;

namespace SumOfIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            long sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                try
                {
                    foreach (var item in input[i])
                    {
                        if (char.IsLetter(item) || char.IsSymbol(item) || item == '.' || item == ',')
                        {
                            throw new FormatException($"The element '{input[i]}' is in wrong format!");
                        }
                        
                    }

                    long result = long.Parse(input[i]);

                    if (result > int.MaxValue || result < int.MinValue)
                    {
                        throw new OverflowException($"The element '{result}' is out of range!");
                        
                    }
                    else
                    {
                        sum += result;
                    }
                    
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{input[i]}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
