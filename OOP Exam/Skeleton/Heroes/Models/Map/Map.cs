using Heroes.Models.Contracts;
using Heroes.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes.Models.Map
{
    public class Map : IMap
    {
        public string Fight(ICollection<IHero> players)
        {
            List<IHero> barbarians = new List<IHero>();
            List<IHero> knights = new List<IHero>();


            foreach (IHero hero in players)
            {
                if (hero.GetType().Name == "Barbarian")
                {
                    barbarians.Add(hero);
                }
                else
                {
                    knights.Add(hero);
                }
            }

            int rowB = 0;
            int rowK = 0;
            int deathKnights = 0;
            int deathBarbarians = 0;

            while (barbarians.Count > 0 && knights.Count > 0)
            {
                bool isTheLastOneBarbarian = false;
                bool isTheLastOneKnight = false;


                for (int k = rowK; k < knights.Count; k++)
                {
                    if (isTheLastOneBarbarian == true)
                    {
                        break;
                    }

                    int damage = knights[k].Weapon.Damage;

                    for (int b = 0; b < barbarians.Count; b++)
                    {
                        if (barbarians[b].IsAlive == true)
                        {
                            barbarians[b].TakeDamage(damage);
                            knights[k].Weapon.DoDamage();
                            if (barbarians[b].Health<=0)
                            {
                                barbarians.Remove(barbarians[b]);
                                deathBarbarians++;
                            }
                        }
                        else continue;

                        if (b== barbarians.Count)
                        {
                            isTheLastOneBarbarian = true;
                            rowK ++;
                            break;
                        }
                        
                    }
                }


                for (int b = rowB; b < barbarians.Count; b++)
                {
                    if (isTheLastOneKnight == true)
                    {
                        break;
                    }

                    int damage = barbarians[b].Weapon.Damage;

                    for (int k = 0; k < knights.Count; k++)
                    {
                        if (knights[k].IsAlive == true)
                        {
                            knights[k].TakeDamage(damage);
                            barbarians[b].Weapon.DoDamage();
                            if (knights[k].Health <= 0)
                            {
                                knights.Remove(knights[k]);
                                deathKnights++;
                            }
                        }
                        else continue;

                        if (k == knights.Count)
                        {
                            isTheLastOneKnight = true;
                            rowB ++;
                            break;
                        }

                    }

                }
            }

            if (barbarians.Count == 0)
            {
                return $"The knights took {deathKnights} casualties but won the battle.";
            }
            else
            {
                return $"The barbarians took {deathBarbarians} casualties but won the battle.";
            }
        }
    }

}
