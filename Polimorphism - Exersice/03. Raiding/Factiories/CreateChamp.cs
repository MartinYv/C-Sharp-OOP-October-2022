using Raiding.Factiories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factiories
{
    public class CreateChamp : ICreateChamp
    {
        IBaseHero ICreateChamp.CreateChamp(string type, string name)
        {
            IBaseHero champ = null;

            if (type == "Druid")
            {
                champ = new Druid(name);
            }

            else if (type == "Paladin")
            {
                champ = new Paladin(name);

            }

            else if (type== "Rogue")
            {
                champ = new Rogue(name);

            }

            else if (type == "Warrior")
            {
                champ = new Warrior(name);

            }

            else
            {
                Console.WriteLine("Invalid hero!");
            }

            return champ;
        }
    }
}
