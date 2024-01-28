using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WARRIOR_BASE_POWER = 100;

        public Warrior(string name) : base(name, WARRIOR_BASE_POWER)
        {
        }

        public override string CastAbility()
        {
            return $"{typeof(Warrior).Name} - {Name} hit for {Power} damage";    
        }
    }
}
