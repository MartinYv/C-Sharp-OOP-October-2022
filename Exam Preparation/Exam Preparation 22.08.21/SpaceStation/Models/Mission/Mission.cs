using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        private IRepository<IAstronaut> astronauts;
        public Mission()
        {
            astronauts = new AstronautRepository();
        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            
            for (int a = 0; a < astronauts.Where(x=>x.Oxygen>0).ToList().Count; a++)
            {
                if (planet.Items.Count==0)
                {
                    break;
                }

                for (int i = 0; i < planet.Items.Count; i++)
                {
                    
                    astronauts.ToList()[a].Breath();

                    if (astronauts.ToList()[a].CanBreath == true)
                    {
                        string item = planet.Items.ToList()[i];

                        astronauts.ToList()[a].Bag.Items.Add(item);
                        
                        planet.Items.Remove(item);
                        i--;
                    }
                    else
                    {
                       // astronauts.Remove(astronauts.ToList()[a]);
                        break;
                    }


                }
            }   
        }
    }
}
