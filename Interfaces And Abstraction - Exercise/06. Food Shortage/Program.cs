using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Food_Shortage
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			List<IBuyer> buyers = new List<IBuyer>();
			IBuyer buyer;

			for (int i = 0; i < n; i++)
			{
				string[] command = Console.ReadLine().Split();

				if (command.Length == 4)
				{
					buyer = new Citizen(command[0], int.Parse(command[1]), command[2], command[3]);
					buyers.Add(buyer);
				}
				else
				{
					buyer = new Rebel(command[0], int.Parse(command[1]), command[2]);
					buyers.Add(buyer);
				}
			}

			int totalFood = 0;

			while (true)
			{
				string name = Console.ReadLine();

				if (name == "End")
				{
					break;
				}

				IBuyer currentBuyer = buyers.FirstOrDefault(n => n.Name == name);

				if (currentBuyer == null)
				{
					continue;
				}

				if (currentBuyer.GetType().Name == "Rebel")
				{
					totalFood += 5;
				}
				else
				{
					totalFood += 10;
				}
			}

			Console.WriteLine(totalFood);
		}
	}
}

