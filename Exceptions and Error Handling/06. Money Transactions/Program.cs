using System;
using System.Collections.Generic;

namespace _06._Money_Transactions
{
	class Program
	{
		static void Main(string[] args)
		{
            Dictionary<int, double> accounts = new Dictionary<int, double>();

            string[] bankAccounts = Console.ReadLine().Split(",");

            foreach (var acc in bankAccounts)
            {
                string[] info = acc.Split("-");

                int id = int.Parse(info[0]);
                double balance = double.Parse(info[1]);

                accounts.Add(id, balance);
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                try
                {
                    int accountId = int.Parse(command[1]);
                    double sum = double.Parse(command[2]);

                    if (!accounts.ContainsKey(accountId))
                    {
                        throw new Exception("Invalid account!");
                    }

                    if (command[0] == "Deposit")
                    {
                        accounts[accountId] += sum;
                    }
                    else if (command[0] == "Withdraw")
                    {

                        if (accounts[accountId] < sum)
                        {
                            throw new Exception("Insufficient balance!");
                        }

                        accounts[accountId] -= sum;
                    }
                    else
                    {
                        throw new Exception("Invalid command!");
                    }

                    Console.WriteLine($"Account {accountId} has new balance: {accounts[accountId]:f2}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Enter another command");

                command = Console.ReadLine().Split();
            }
        }
	}
}
