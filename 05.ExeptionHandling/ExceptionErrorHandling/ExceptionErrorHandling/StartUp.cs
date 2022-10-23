namespace ExceptionErrorHandling
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            
            try
            {
                double n = double.Parse(Console.ReadLine());
                if (n < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }
                else
                {
                    double result = Math.Sqrt(n);
                    Console.WriteLine(result);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
