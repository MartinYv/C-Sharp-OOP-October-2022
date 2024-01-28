using Raiding.Core.Interfaces;
using Raiding.Factiories;
using Raiding.Factiories.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {

       private readonly ICreateChamp createChamp;
        private readonly List<IBaseHero> champs;

        public Engine()
        {
            createChamp = new CreateChamp();
            champs= new List<IBaseHero>();
        }

        public void Run()
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

               
                IBaseHero champ = createChamp.CreateChamp(type, name);

                if (champ == null)
                {
                    i--;
                    continue;
                }
                else
                {
                   champs.Add(champ);
                    
                }

            }

            int bossHealth= int.Parse(Console.ReadLine());
            
            int champsTotalDmg = 0;

            foreach (IBaseHero champ in champs)
            {
                champsTotalDmg += champ.Power;
                Console.WriteLine(champ.CastAbility());
            }


            if (bossHealth <= champsTotalDmg)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
