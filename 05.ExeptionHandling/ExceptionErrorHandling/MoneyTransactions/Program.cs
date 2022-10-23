using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            string[] input = Console.ReadLine().Split(",");
            for (int i = 0; i < input.Length; i++)
            {
                string[] accountData = input[i].Split("-");
                int accountNumber = int.Parse(accountData[0]);
                double sum = double.Parse(accountData[1]);
                accounts.Add(accountNumber, sum);
            }

            string[] commands = Console.ReadLine().Split();
            while (commands[0] != "End")
            {
                try
                {
                    int accountNubmer = int.Parse(commands[1]);
                    double balance = double.Parse(commands[2]);
                    if (commands[0] == "Deposit")
                    {
                        if (!accounts.ContainsKey(int.Parse(commands[1])))
                        {
                            throw new NullReferenceException("Invalid account!");
                        }

                        accounts[accountNubmer] += balance;
                    }
                    else if (commands[0] == "Withdraw")
                    {
                        if (accounts[accountNubmer] < balance)
                        {
                            throw new OverflowException("Insufficient balance!");
                        }

                        accounts[accountNubmer] -= balance;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                    Console.WriteLine($"Account {accountNubmer} has new balance: {accounts[accountNubmer]:F2}");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (NullReferenceException nre)
                {
                    Console.WriteLine(nre.Message);
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                commands = Console.ReadLine().Split();
            }
        }

    }
}
