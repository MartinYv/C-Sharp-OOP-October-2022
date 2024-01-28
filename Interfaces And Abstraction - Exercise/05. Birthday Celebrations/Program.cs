using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Birthday_Celebrations
{
	class Program
	{
		static void Main(string[] args)
		{
            IIdentifiable identifiable;

            List<IIdentifiable> inhabitants = new List<IIdentifiable>();

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                if (command[0] == "Robot")
                {
                    identifiable = new Robot(command[1], command[2]);
                    inhabitants.Add(identifiable);
                }
                if (command[0] == "Citizen")
                {
                    identifiable = new Citizen(command[1], int.Parse(command[2]), command[3], command[4]);
                    inhabitants.Add(identifiable);
                }
                if (command[0] == "Pet")
                {
                    identifiable = new Pet(command[1], command[2]);
                    inhabitants.Add(identifiable);
                }

                command = Console.ReadLine().Split();
            }

            string year = Console.ReadLine();

            foreach (var inhabitant in inhabitants.Where(i => i.Birthdate != null && i.Birthdate.EndsWith(year)))
            {
                Console.WriteLine(inhabitant.Birthdate);
            }
        }
	}
}
