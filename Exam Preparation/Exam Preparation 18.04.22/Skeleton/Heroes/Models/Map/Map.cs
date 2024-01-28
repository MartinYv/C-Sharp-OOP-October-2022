using Heroes.Models.Contracts;
using Heroes.Repositories;
using Heroes.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        private IRepository<IHero> heroes;

        public Map()
        {
            heroes = new HeroRepository();
        }
        public string Fight(ICollection<IHero> players)
        {
            var knights = players.Where(x => x.GetType().Name == "Knight").ToList(); 
            var barbarians = players.Where(x => x.GetType().Name == "Barbarian").ToList();


            int deathKnights = 0;
            int deathBarbarians = 0;

            while (knights.Count != deathKnights && barbarians.Count != deathBarbarians)
            {

                foreach (var knight in knights.Where(x => x.IsAlive == true))
                {

                    foreach (var barbarian in barbarians.Where(x => x.IsAlive == true))
                    {
                    int knightDamage = knight.Weapon.DoDamage();
                        barbarian.TakeDamage(knightDamage);

                        if (barbarian.Health <= 0)
                        {
                            deathBarbarians += 1;
                            heroes.Remove(barbarian);
                        }
                    }
                }


                foreach (var barbarian in barbarians.Where(x => x.IsAlive == true))
                {
                    
                    foreach (var knight in knights.Where(x => x.IsAlive == true))
                    {
                        int barbarianDamage = barbarian.Weapon.DoDamage();
                        knight.TakeDamage(barbarianDamage);

                        if (knight.Health <= 0)
                        {
                            deathKnights += 1;
                            heroes.Remove(knight);

                        }
                    }
                }
            }

            string result = barbarians.Count == deathKnights ? $"The barbarians took {deathBarbarians} casualties but won the battle." :
                                                 $"The knights took {deathKnights} casualties but won the battle.";

            return result.TrimEnd();
        }
    }
}
