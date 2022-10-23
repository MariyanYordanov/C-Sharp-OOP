using System;
using System.Linq;

namespace PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integerElements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int countException = 0;
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] inputData = input.Split();

                    if (inputData[0] == "Replace")
                    {
                        if (!int.TryParse(inputData[1], out int index))
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }

                        if (!int.TryParse(inputData[2], out int element))
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }

                        if (index < 0 || index >= integerElements.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        integerElements[index] = element;
                    }
                    else if (inputData[0] == "Print")
                    {
                        if (!int.TryParse(inputData[1], out int start))
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }

                        if (!int.TryParse(inputData[2], out int end))
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }

                        if (start < 0 || start >= integerElements.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        if (end < 0 || end >= integerElements.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        int length = end - start + 1;
                        int[] printArray = new int[length];
                        for (int i = 0; i < length; i++)
                        {
                            printArray[i] = integerElements[start + i];
                            if (i == 0)
                            {
                                Console.Write($"{printArray[i]}");
                            }
                            else
                            {
                                Console.Write($", {printArray[i]}");
                            }
                            
                        }

                        Console.WriteLine();
                    }
                    else if (inputData[0] == "Show")
                    {
                        if (!int.TryParse(inputData[1], out int index))
                        {
                            throw new FormatException("The variable is not in the correct format!");
                        }

                        if (index < 0 || index >= integerElements.Length)
                        {
                            throw new ArgumentException("The index does not exist!");
                        }

                        Console.WriteLine(integerElements[index]);
                    }
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    countException++;
                } 
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    countException++;
                }

                if (countException == 3)
                {
                    break;
                }
            }

            for (int i = 0; i < integerElements.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write($"{integerElements[i]}");
                }
                else
                {
                    Console.Write($", {integerElements[i]}");
                }

            }
        }
    }
}
